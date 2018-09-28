using Newtonsoft.Json;
namespace PenzGTUSchedule_schema.Schema.Common
{
    public class Lesson
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}