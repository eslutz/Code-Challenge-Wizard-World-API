using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class Spell
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = "unknown";
        [JsonPropertyName("name")]
        public string Name { get; set; } = "unknown";
        [JsonPropertyName("incantation")]
        public string Incantation { get; set; } = "unknown";
        [JsonPropertyName("effect")]
        public string Effect { get; set; } = "unknown";
        [JsonPropertyName("canBeVerbal")]
		public bool? CanBeVerbal { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; } = "unknown";
        [JsonPropertyName("light")]
        public string Light { get; set; } = "unknown";
        [JsonPropertyName("creator")]
        public string Creator { get; set; } = "unknown";
    }
}

