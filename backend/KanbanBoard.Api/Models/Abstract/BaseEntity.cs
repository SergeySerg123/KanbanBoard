using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KanbanBoard.Api.Models.Abstract
{
    public abstract class BaseEntity
    {
        private DateTime _createdAt;

        public BaseEntity()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = (value == null || value == DateTime.MinValue) ? DateTime.Now : value;
        }
        public DateTime UpdatedAt { get; set; }
    }
}
