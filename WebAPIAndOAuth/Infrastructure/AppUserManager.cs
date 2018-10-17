using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Text.RegularExpressions;

namespace WebAPIAndOAuth.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> userStore) : base(userStore) { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext ctx)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(ctx.Get<AuthDbContext>()));

            userMgr.UserValidator = new EnhancementUserValidator(userMgr)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            userMgr.PasswordValidator = new EnhancementPasswordValidator(3)
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireNonLetterOrDigit = true,
                RequireUppercase = true
            };

            return userMgr;
        }
    }
}