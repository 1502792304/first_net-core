using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_net__core.midd
{
    public class RequestIPMyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestIPMyMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger<RequestIPMyMiddleware>();
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("ip:");
            string ip= context.Connection.RemoteIpAddress.ToString();
            await _next.Invoke(context); //执行下一个中间件
        }

    }
}
