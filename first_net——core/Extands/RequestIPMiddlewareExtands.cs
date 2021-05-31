using first_net__core.midd;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_net__core.Extands
{
    public static class RequestIPMiddlewareExtands
    {
        public static IApplicationBuilder UseMyIp(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestIPMyMiddleware>();
            return app;
        }
    }
}
