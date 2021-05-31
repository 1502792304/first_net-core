using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_net__core.midd
{
    public class RouterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RouterMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger<RequestIPMyMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            //应该只是一个url拦截检测作用,可以伪造静态页
            context.Response.ContentType = "text/html;charset=UTF-8";
            if (context.Request.Path == "/help")
            {
                await context.Response.WriteAsync("Hello terminal middleware!");
                return;
            }
            if (context.Request.Path == "/home/test.html")
            {
                await context.Response.WriteAsync("这是伪静态页");
                context.Response.Redirect("/home/index");
                return;
            }
            await _next.Invoke(context); //执行下一个中间件
        }
    }

    public static class RouterMiddlewareExtands
    {
        public static IApplicationBuilder Res(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<RouterMiddleware>();
            return applicationBuilder;
        }
    }
  

}
