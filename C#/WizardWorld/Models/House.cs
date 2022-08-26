using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class House
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("name")]
		public string? Name { get; set; }
		[JsonPropertyName("houseColours")]
		public string? HouseColors { get; set; }
		[JsonPropertyName("founder")]
		public string? Founder { get; set; }
		[JsonPropertyName("animal")]
		public string? Animal { get; set; }
		[JsonPropertyName("element")]
		public string? Element { get; set; }
		[JsonPropertyName("ghost")]
		public string? Ghost { get; set; }
		[JsonPropertyName("commonRoom")]
		public string? CommonRoom { get; set; }
		[JsonPropertyName("heads")]
		public List<HouseHead>? Heads { get; set; }
		[JsonPropertyName("traits")]
		public List<Trait>? Traits { get; set; }
	}

	public class HouseHead
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("firstName")]
		public string? FirstName { get; set; }
		[JsonPropertyName("lastName")]
		public string? LastName { get; set; }
	}

	public class Trait
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	}
}

