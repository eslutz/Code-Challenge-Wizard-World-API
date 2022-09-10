using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class Wizard
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = "unknown";
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = "unknown";
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = "unknown";
        [JsonPropertyName("elixirs")]
        public List<Elixir> Elixirs { get; set; } = new List<Elixir>();

	}
}

