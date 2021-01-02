using Newtonsoft.Json;

namespace KanbanBoard.Api.DTO
{
    public sealed class GoalDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }       
        
        [JsonProperty("boardId")]
        public string BoardId { get; set; }
        
        [JsonIgnore]
        public string AuthorId { get; set; }
    }
}
