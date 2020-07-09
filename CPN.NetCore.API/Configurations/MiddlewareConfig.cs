using CPN.NetCore.API.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPN.NetCore.API.Configurations
{
    public static class MiddlewareConfig
    {
        public static void UseMiddlewares(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            app.UseMiddleware<ExceptionMiddlewarecs>();
        }
    }
}
