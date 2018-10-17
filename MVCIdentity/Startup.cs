using System;
using System.Threading.Tasks;
using System.Diagnostics;
using Owin;
using Microsoft.Owin;

using MVCIdentity.Infrastructure;

[assembly: OwinStartup(typeof(MVCIdentity.Startup))]

namespace MVCIdentity
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.Use<LoggerMiddleware>(new TextLogger());
            
            

            //app.Run(ctx =>
            //{
            //    ctx.Response.ContentType = "text/plain";
                
            //    return ctx.Response.WriteAsync("Hello world!");
            //});
        }
    }
}
