namespace KanbanBoard.BuildingBlocks.EventBus.RabbitMQEventBus
{
    public interface IRabbitManager
    {
        void Publish<T>(T message, string exchangeName, string exchangeType, string routeKey)
            where T : class;
    }
}
