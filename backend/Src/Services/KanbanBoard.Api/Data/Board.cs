using KanbanBoard.Services.Goals.Api.Models.Abstract;
using MongoDB.Bson;
using System.Collections.Generic;

namespace KanbanBoard.Services.Goals.Api.Models
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }
        public string HeadColor { get; set; }
        public string BodyColor { get; set; }

        public ObjectId Author { get; set; }
        public ICollection<ObjectId> GoalIds { get; set; }
    }
}
