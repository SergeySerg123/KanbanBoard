using KanbanBoard.Services.Goals.Api.Interfaces;

namespace KanbanBoard.Services.Goals.Api.Models
{
    public class GoalstoreDatabaseSettings : IGoalstoreDatabaseSettings
    {
        public string GoalsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
