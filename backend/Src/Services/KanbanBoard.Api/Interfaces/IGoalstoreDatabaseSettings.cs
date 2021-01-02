namespace KanbanBoard.Api.Interfaces
{
    public interface IGoalstoreDatabaseSettings
    {
        string GoalsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
