using EventBus.Base.Standard;
using MailService.Api.IntegrationEvents.EventHandling;
using MailService.Api.IntegrationEvents.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MailService.Api.Extensions
{
    public static class EventBusExtension
    {
        public static IEnumerable<IIntegrationEventHandler> GetHandlers()
        {
            return new List<IIntegrationEventHandler>
        {
            new CreatedGoalIntegrationEventHandler()
        };
        }

        public static IApplicationBuilder SubscribeToEvents(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<CreatedGoalIntegrationEvent, CreatedGoalIntegrationEventHandler>();

            return app;
        }
    }
}
