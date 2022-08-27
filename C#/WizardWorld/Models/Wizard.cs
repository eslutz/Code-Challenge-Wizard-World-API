using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WizardWorld.Models
{
	public class Wizard
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
		[JsonPropertyName("lastName")]
        public string? LastName { get; set; }
		[JsonPropertyName("elixirs")]
        public List<Elixir>? Elixirs { get; set; }

	}
}

