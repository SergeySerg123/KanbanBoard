using RabbitMQ.Client;
using System;

namespace KanbanBoard.BuildingBlocks.EventBus.RabbitMQEventBus
{
    public interface IRabbitMQPersistentConnection
       : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
