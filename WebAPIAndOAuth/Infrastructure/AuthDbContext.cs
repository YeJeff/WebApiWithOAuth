using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Validation;
using WebAPIAndOAuth.Models;

namespace WebAPIAndOAuth.Infrastructure
{
    [DbConfigurationType(typeof(AuthDbConfig))]
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public AuthDbContext() : base("name=AuthDbContext")
        {
            //this.Configuration.ProxyCreationEnabled = false;
        }

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


        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }
    }

    class DropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<AuthDbContext>
    {
        protected override void Seed(AuthDbContext context)
        {
            context.Users.Add(new AppUser { UserName = "lj", Email = "123@qq.com", PasswordHash = "ADLAITS97fK9o8wWPSuQ7pmZcE2i9Dz2hLyn+T7GmIwxxbA1JAEGTaJT5o5Rn+LreA==" });
            context.Clients.Add(new AppClient { ClientId = "B9684437-B69A-45BF-BDC6-FD6EEC14026A", ClientSecret = "6USxYJQtPaACHycrFKiciUIY51HZKw+cCaL6JusjL0A=", Name = "TestClient", ApplicationType = ApplicationTypes.NativeConfidential, Active = true, RefreshTokenLifeTime = 14400, AllowedOrigin = "*" });
            context.SaveChanges();
            base.Seed(context);
        }
    }

    class AuthDbConfig : DbConfiguration
    {
        public AuthDbConfig()
        {
            this.AddInterceptor(new EFCommandInterceptor());
        }
    }

    class EFCommandInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo("NonQueryExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            LogInfo("ReaderExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuted", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        public void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo("ScalarExecuting", String.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
        }

        private void LogInfo(string command, string commandText)
        {
            System.Diagnostics.Debug.WriteLine("Intercepted on: {0} :- {1} ", command, commandText);
        }
    }
}