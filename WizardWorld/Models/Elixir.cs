using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class Elixir
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = "unknown";
        [JsonPropertyName("name")]
        public string Name { get; set; } = "unknown";
        [JsonPropertyName("effect")]
        public string Effect { get; set; } = "unknown";
        [JsonPropertyName("sideEffects")]
        public string SideEffects { get; set; } = "unknown";
        [JsonPropertyName("idcharacteristices")]
        public string Characteristices { get; set; } = "unknown";
        [JsonPropertyName("time")]
        public string Time { get; set; } = "unknown";
        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; } = "unknown";
        [JsonPropertyName("ingredients")]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        [JsonPropertyName("inventors")]
        public List<Inventor> Inventors { get; set; } = new List<Inventor>();
		[JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; } = "unknown";
    }

	public class Ingredient
	{
		[JsonPropertyName("id")]
        public string Id { get; set; } = "unknown";
        [JsonPropertyName("name")]
        public string Name { get; set; } = "unknown";
    }

	public class Inventor
	{
		[JsonPropertyName("id")]
        public string Id { get; set; } = "unknown";
        [JsonPropertyName("name")]
        public string Name { get; set; } = "unknown";
    }

}
