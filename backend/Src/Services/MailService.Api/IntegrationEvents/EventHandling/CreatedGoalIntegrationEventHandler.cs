using KanbanBoard.BuildingBlocks.EventBus.Settings.Abstractions;
using KanbanBoard.Services.MailService.Api.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace KanbanBoard.Services.MailService.Api.IntegrationEvents.EventHandling
{
    public class CreatedGoalIntegrationEventHandler 
        : IIntegrationEventHandler<CreatedGoalIntegrationEvent>
    {
        private readonly ILogger<CreatedGoalIntegrationEvent> _logger;

        public CreatedGoalIntegrationEventHandler(ILogger<CreatedGoalIntegrationEvent> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(CreatedGoalIntegrationEvent @event)
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);
        }
    }
}
