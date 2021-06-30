using System;
using System.Text.Json.Serialization;

namespace pdouelle.QueryStringHelper.Debug
{
    public class Class1
    {
        [JsonPropertyName("lecoucou.teso")]
        public bool IncludeBlobs { get; set; }
        public Guid[] NotificationTemplateIds { get; set; }
        public string Article { get; set; } = "TR";
    }
}