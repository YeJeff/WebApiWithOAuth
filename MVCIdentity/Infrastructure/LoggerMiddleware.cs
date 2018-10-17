using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace MVCIdentity.Infrastructure
{
    public class LoggerMiddleware : OwinMiddleware
    {
        private readonly ILog _logger;

        public LoggerMiddleware(OwinMiddleware next, ILog logger) : base(next) => _logger = logger;

        public override async Task Invoke(IOwinContext context)
        {
            _logger.LogInfo("Middleware begin");
            await this.Next.Invoke(context);
            _logger.LogInfo("Middleware end");
        }
    }

    public interface ILog
    {
        void LogInfo(string output);
        void LogError(string output);
    }

    public class TextLogger : ILog
    {
        public void LogError(string output)
        {
            System.Diagnostics.Debug.WriteLine($"Error: {output}");
        }

        public void LogInfo(string output)
        {
            System.Diagnostics.Debug.WriteLine($"Info: {output}");
        }
    }
}