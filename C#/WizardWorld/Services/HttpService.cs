using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WizardWorld.Services
{
	public class HttpService
	{
		private readonly HttpClient _httpClient = new();


		public async Task<string> GetAsync(Uri endpointUrl)
		{
            var resp = await _httpClient.GetAsync(endpointUrl);

            return await resp.Content.ReadAsStringAsync();
        }
	}
}

