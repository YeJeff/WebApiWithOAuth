using System;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity.Owin;
using WebAPIAndOAuth.Infrastructure;
using WebAPIAndOAuth.Models;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(WebAPIAndOAuth.Startup))]
namespace WebAPIAndOAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            app.CreatePerOwinContext(AuthDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);



            HttpConfiguration httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);

            OAuthConfig(app);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);
        }

        private void OAuthConfig(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oauthOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                // AuthorizeEndpointPath=new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }

    class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            var formCollection = await context.Request.ReadFormAsync();
            var grant_type = formCollection["grant_type"];

            // if your client_id is passed as a form param, you'll have to get it by doing context.TryGetFormCredentials(out clientId, out clientSecret);
            // if your client_id is passed as an Authorization header, you can get it by doing context.TryGetBasicCredentials(out clientId, out clientSecret);
            // once you've got the client_id from your request, do context.Validated(clientId), this will set your context.ClientId property, 
            // this property will always be null until you've done context.Validated() or context.Validated(string clientId)
            if (!context.TryGetBasicCredentials(out string clientId, out string clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (!string.IsNullOrEmpty(clientId))
            {
                AppClient client = await context.OwinContext.Get<AuthDbContext>().Clients.AsNoTracking()
                    .Where(c => c.ClientId == context.ClientId).FirstOrDefaultAsync();

                if (client is null)
                {
                    context.SetError("invalid_clientId", $"Client '{context.ClientId}' is not registered in the system.");
                    return;
                }


                if (client.ApplicationType == ApplicationTypes.NativeConfidential && string.Compare(grant_type, "password", false) == 0)
                {
                    if (string.IsNullOrEmpty(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret should be sent.");
                        return;
                    }
                    else
                    {
                        if (client.ClientSecret != Utility.GetHashBySHA256(clientSecret))
                        {
                            context.SetError("invalid_clientId", "Client secret is invalid.");
                            return;
                        }
                    }
                }

                if (!client.Active)
                {
                    context.SetError("invalid_clientId", "Client is inactive.");
                    return;
                }

                context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
                context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

                context.Validated(clientId);
                return;
            }

            //Remove the comments from the line context.SetError and comment context.Validate()
            //if you want to force sending clientId/secrects once obtain access tokens.
            context.Validated();
            //context.SetError("invalid_clientId", "ClientId should be sent.");

        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin"
                , new[] { context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*" });

            AppUser user = await context.OwinContext.GetUserManager<AppUserManager>()
                .FindAsync(context.UserName, context.Password);

            if (user is null)
            {
                context.SetError("invalid_grant", "The username or password is incorrect");
                return;
            }

            ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));

            var authProps = new AuthenticationProperties();
            authProps.Dictionary.Add("as:client_id", context.ClientId ?? string.Empty);
            authProps.Dictionary.Add("userName", context.UserName);

            var ticket = new AuthenticationTicket(identity, authProps);
            context.Validated(ticket);
        }

        // 通过获取的refresh_token刷新access_token
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClientId = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClientId = context.ClientId;

            if (originalClientId != currentClientId)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity(context.Ticket.Identity);
            identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));

            var ticket = new AuthenticationTicket(identity, context.Ticket.Properties);
            context.Validated(ticket);
            return Task.FromResult<object>(null);

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> prop in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(prop.Key, prop.Value);
            }
            return Task.FromResult<object>(null);
        }
    }

    class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientId = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientId))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("N");

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var refreshToken = new AppRefreshToken()
            {
                Id = Utility.GetHashBySHA256(refreshTokenId),
                ClientId = clientId,
                //Subject = context.OwinContext.Authentication.User.Identity.Name,
                Subject = context.Ticket.Identity.Name,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = refreshToken.IssuedUtc;
            context.Ticket.Properties.ExpiresUtc = refreshToken.ExpiresUtc;

            refreshToken.ProtectedTicket = context.SerializeTicket();

            using (AuthRepository authRepo = new AuthRepository())
            {
                if (await authRepo.AddRefreshTokenAsync(refreshToken))
                {
                    context.SetToken(refreshTokenId);
                }
            }
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin"
                , new[] { context.OwinContext.Get<string>("as:clientAllowedOrigin") });

            var hashedTokenId = Utility.GetHashBySHA256(context.Token);
            var dbContext = context.OwinContext.Get<AuthDbContext>();
            using (AuthRepository authRepo = new AuthRepository())
            {
                var refreshToken = await authRepo.FindSingleRefreshTokenAsync(hashedTokenId);

                if (!(refreshToken is null))
                {
                    context.DeserializeTicket(refreshToken.ProtectedTicket);
                    await authRepo.RemoveRefreshTokenAsync(hashedTokenId);
                }
            }
        }
    }
}
