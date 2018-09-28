using Newtonsoft.Json;

namespace PenzGTUSchedule_schema.Schema.Common
{
    public class Subject
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
        [JsonProperty("week", Required = Required.Always)]
        public int Week { get; set; }
        [JsonProperty("lesson")]
        public Lesson Lesson { get; set; }
        [JsonProperty("teacher")]
        public Teacher Teacher { get; set; }
        [JsonProperty("place")]
        public string Place { get; set; }
    }
}

