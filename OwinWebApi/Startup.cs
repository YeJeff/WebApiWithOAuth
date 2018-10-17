using System;
using Owin;
using System.Configuration;

namespace OwinWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(ctx=> {
                ctx.Response.ContentType = "text/plain;charset=utf-8;";
                return ctx.Response.WriteAsync($"Owin startup~ {DateTime.Now.ToLongDateString()}");
            });
        }

        public void GetWebConfigSetion()
        {
            var configSection = ConfigurationManager.GetSection("unity");
        }
    }
}