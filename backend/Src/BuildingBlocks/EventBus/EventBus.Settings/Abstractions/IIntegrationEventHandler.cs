using KanbanBoard.BuildingBlocks.EventBus.Settings.Events;
using System.Threading.Tasks;

namespace KanbanBoard.BuildingBlocks.EventBus.Settings.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
