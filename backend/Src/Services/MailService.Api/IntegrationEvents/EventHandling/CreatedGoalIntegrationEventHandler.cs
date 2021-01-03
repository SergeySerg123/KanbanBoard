﻿using EventBus.Base.Standard;
using KanbanBoard.Services.MailService.Api.IntegrationEvents.Events;
using System.Threading.Tasks;

namespace KanbanBoard.Services.MailService.Api.IntegrationEvents.EventHandling
{
    public class CreatedGoalIntegrationEventHandler 
        : IIntegrationEventHandler<CreatedGoalIntegrationEvent>
    {
        public CreatedGoalIntegrationEventHandler()
        {

        }

        public async Task Handle(CreatedGoalIntegrationEvent @event)
        {
            //Handle the CreatedGoalIntegrationEvent event here.
        }
    }
}
