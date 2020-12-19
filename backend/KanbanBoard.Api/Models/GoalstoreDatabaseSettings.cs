using KanbanBoard.Api.Interfaces;

namespace KanbanBoard.Api.Models
{
    public class GoalstoreDatabaseSettings : IGoalstoreDatabaseSettings
    {
        public string GoalsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
