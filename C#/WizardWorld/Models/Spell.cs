using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class Spell
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("incantation")]
        public string? Incantation { get; set; }
		[JsonPropertyName("effect")]
        public string? Effect { get; set; }
		[JsonPropertyName("canBeVerbal")]
        public bool CanBeVerbal { get; set; }
		[JsonPropertyName("type")]
        public string? Type { get; set; }
		[JsonPropertyName("light")]
        public string? Light { get; set; }
		[JsonPropertyName("creator")]
        public string? Creator { get; set; }
	}
}

