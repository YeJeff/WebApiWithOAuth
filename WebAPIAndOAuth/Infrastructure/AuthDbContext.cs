using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebAPIAndOAuth.Models;

namespace WebAPIAndOAuth.Infrastructure
{
    public class AuthDbContext:IdentityDbContext<AppUser>
    {
        public AuthDbContext() : base("name=AuthDbContext") { }

        static AuthDbContext() => Database.SetInitializer(new DropCreateDatabaseIfModelChanges());

        public static AuthDbContext Create() => new AuthDbContext();

        #region 数据集(表)
        /// <summary>
        /// 调用WebApi的客户端表
        /// </summary>
        public DbSet<AppClient> Clients { get; set; }

        /// <summary>
        /// RefreshToken存储表
        /// </summary>
        public DbSet<AppRefreshToken> RefreshTokens { get; set; }
        #endregion
        #region test
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BillingDetail> BillingDetails { get; set; }
        #endregion
    }

    class DropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<AuthDbContext>
    {
        protected override void Seed(AuthDbContext context)
        {
            context.Users.Add(new AppUser{ UserName="lj", Email="123@qq.com", PasswordHash= "ADLAITS97fK9o8wWPSuQ7pmZcE2i9Dz2hLyn+T7GmIwxxbA1JAEGTaJT5o5Rn+LreA==" });
            context.Clients.Add(new AppClient {ClientId = "B9684437-B69A-45BF-BDC6-FD6EEC14026A", ClientSecret = "6USxYJQtPaACHycrFKiciUIY51HZKw+cCaL6JusjL0A=", Name = "TestClient", ApplicationType = ApplicationTypes.NativeConfidential, Active = true, RefreshTokenLifeTime = 14400, AllowedOrigin = "*" });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}