using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PenzGTUSchedule_schema.JsonConverters;

namespace PenzGTUSchedule_schema.Schema.Common
{
    public class RootItem
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
        [JsonProperty("day", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DayOfWeek Day { get; set; }
        [JsonProperty("time", Required = Required.Always)]
        [JsonConverter(typeof(DateTimeToShortString))]
        public DateTime Time { get; set; }
        [JsonProperty("subjects")]
        public IEnumerable<Subject> Subjects { get; set; } 
    }
}
