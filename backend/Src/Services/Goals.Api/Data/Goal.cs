using KanbanBoard.Services.Goals.Api.Models.Abstract;
using MongoDB.Bson;

namespace KanbanBoard.Services.Goals.Api.Models
{
    public class Goal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObjectId BoardId { get; set; }
        public ObjectId AuthorId { get; set; }
    }
}
