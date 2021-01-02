using EventBus.Base.Standard;
using MailService.Api.IntegrationEvents.Events;
using System.Threading.Tasks;

namespace MailService.Api.IntegrationEvents.EventHandling
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
