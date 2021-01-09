using MongoDB.Bson;
using System;

namespace KanbanBoard.Services.Goals.Api.Models.Abstract
{
    public abstract class BaseEntity
    {
        private DateTime _createdAt;

        public BaseEntity()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public ObjectId Id { get; set; }
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = (value == null || value == DateTime.MinValue) ? DateTime.Now : value;
        }
        public DateTime UpdatedAt { get; set; }
    }
}
