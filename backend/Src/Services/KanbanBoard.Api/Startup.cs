using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using KanbanBoard.Services.Goals.Api.Filters;
using KanbanBoard.Services.Goals.Api.Extensions;
using KanbanBoard.BuildingBlocks.EventBus.Settings.Abstractions;

namespace KanbanBoard.Services.Goals.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRabbit(Configuration);
            services.RegisterCustomServices(Configuration);
            services.RegisterCustomRepositories();
            services.RegisterMappingProfiles();

            services.RegisterRabbitMQEventBus(Configuration);


            services.AddCors();

            services
                .AddMvcCore(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddAuthorization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                //.AddFluentValidation();

            services.ConfigureCustomValidationErrors();

            services.ConfigureJwt(Configuration);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            //eventBus.Subscribe<CreatedGoalIntegrationEvent, CreatedGoalIntegrationEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Token-Expired")
                .AllowCredentials()
                .WithOrigins("http://localhost:4200"));

            app.UseRouting();
            
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            ConfigureEventBus(app);
        }
    }
}
