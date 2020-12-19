using KanbanBoard.Api.Models.Abstract;

namespace KanbanBoard.Api.Models
{
    public class Goal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AppUser Author { get; set; }
    }
}
