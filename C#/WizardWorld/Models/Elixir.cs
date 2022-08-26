using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class Elixir
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("effect")]
        public string? Effect { get; set; }
		[JsonPropertyName("sideEffects")]
        public string? SideEffects { get; set; }
		[JsonPropertyName("idcharacteristices")]
        public string? Characteristices { get; set; }
		[JsonPropertyName("time")]
        public string? Time { get; set; }
		[JsonPropertyName("difficulty")]
        public string Difficulty { get; set; } = "Unknown";
		[JsonPropertyName("ingredients")]
        public List<Ingredient>? Ingredients { get; set; }
		[JsonPropertyName("inventors")]
        public List<Inventor>? Inventors { get; set; }
		[JsonPropertyName("manufacturer")]
        public string? Manufacturer { get; set; }
	}

	public class Ingredient
	{
		[JsonPropertyName("id")]
        public string Id { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
    }

	public class Inventor
	{
		[JsonPropertyName("id")]
        public string Id { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
    }

}
