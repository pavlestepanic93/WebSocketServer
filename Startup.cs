using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.WebSockets;
using System.Threading;
using WebSocketServer.Middleware;

namespace WebSocketServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebSocketManager();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets();

            app.UseWebSocketServer();

            app.Run(async context =>
            {
                Console.WriteLine("Hello from the 3rd request delegate.");
                await context.Response.WriteAsync("Hello from the 3rd request delegate!!!.");
            });
        }
        public void WriteRequestParam(HttpContext context)
        {
            Console.WriteLine("Request Method: " + context.Request.Method);
            Console.WriteLine("Request Protocol: " + context.Request.Protocol);

            if(context.Request.Headers != null)
            {
                foreach(var h in context.Request.Headers)
                {
                    Console.WriteLine("--> " + h.Key + " : " +h.Value);
                }
            }
        }
    }
}
