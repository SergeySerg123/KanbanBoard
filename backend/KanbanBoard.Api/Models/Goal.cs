using KanbanBoard.Api.Models.Abstract;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace KanbanBoard.Api.Models
{
    public class Goal : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }

        //[JsonProperty]
        //public ObjectId BoardId { get; set; }

        //[JsonIgnore]
        //public ObjectId Author { get; set; }
    }
}
