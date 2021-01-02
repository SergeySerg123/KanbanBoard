using KanbanBoard.Api.Models.Abstract;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace KanbanBoard.Api.Models
{
    public class Goal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObjectId BoardId { get; set; }
        public ObjectId AuthorId { get; set; }
    }
}
