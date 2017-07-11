using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace devWarsztaty_GatewayService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SetupRoutes(app);            
        }

        private void SetupRoutes(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapPost("loans", context =>
            {
                var gatewayModule = new GatewayModule(new ScoringService(), new MatchingService());
                return gatewayModule.GetLoan(context);
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}
