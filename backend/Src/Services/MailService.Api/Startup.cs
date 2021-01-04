using KanbanBoard.BuildingBlocks.EventBus.RabbitMQEventBus;
using KanbanBoard.BuildingBlocks.EventBus.Settings.Abstractions;
using KanbanBoard.Services.MailService.Api.Extensions;
using KanbanBoard.Services.MailService.Api.IntegrationEvents.EventHandling;
using KanbanBoard.Services.MailService.Api.IntegrationEvents.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KanbanBoard.Services.MailService.Api
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
            services.RegisterRabbitMQEventBus(Configuration);
            services.AddControllers();
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<CreatedGoalIntegrationEvent, CreatedGoalIntegrationEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            ConfigureEventBus(app);
        }
    }
}
