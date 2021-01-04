using KanbanBoard.BuildingBlocks.EventBus.Settings.Events;

namespace KanbanBoard.Services.Goals.Api.IntegrationEvents.Events
{
    public class CreatedGoalIntegrationEvent : IntegrationEvent
    {

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string AuthorId { get; private set; }
        public string Email { get; private set; }

        public CreatedGoalIntegrationEvent(string name, string description, string authorId, string email)
        {
            Name = name;
            Description = description;
            AuthorId = authorId;
            Email = email;
        }
    }
}
