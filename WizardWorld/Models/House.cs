using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class House
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = "unknown";
        [JsonPropertyName("name")]
		public string Name { get; set; } = "unknown";
        [JsonPropertyName("houseColours")]
		public string HouseColors { get; set; } = "unknown";
        [JsonPropertyName("founder")]
		public string Founder { get; set; } = "unknown";
        [JsonPropertyName("animal")]
		public string Animal { get; set; } = "unknown";
        [JsonPropertyName("element")]
		public string Element { get; set; } = "unknown";
        [JsonPropertyName("ghost")]
		public string Ghost { get; set; } = "unknown";
        [JsonPropertyName("commonRoom")]
		public string CommonRoom { get; set; } = "unknown";
		[JsonPropertyName("heads")]
		public List<HouseHead> Heads { get; set; } = new List<HouseHead>();
		[JsonPropertyName("traits")]
		public List<Trait> Traits { get; set; } = new List<Trait>();
	}

	public class HouseHead
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = "unknown";
        [JsonPropertyName("firstName")]
		public string FirstName { get; set; } = "unknown";
        [JsonPropertyName("lastName")]
		public string LastName { get; set; } = "unknown";
    }

	public class Trait
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = "unknown";
        [JsonPropertyName("name")]
		public string Name { get; set; } = "unknown";
    }
}

