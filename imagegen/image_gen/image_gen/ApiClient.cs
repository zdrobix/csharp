using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_gen
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http.Headers;
	using System.Text;
	using System.Text.Json;
	using System.Threading.Tasks;

	namespace starwars
	{
		internal class ApiClient
		{
			private HttpClient _client { get; init; }
			private List<string> _credentials { get; init; }
			public ApiClient (List<string> credentials)
			{
				this._client = new HttpClient ();
				this._client.BaseAddress = new Uri("https://api.unsplash.com");
				this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", credentials.ElementAt(1).Trim());
				this._credentials = credentials;
			}
			public async Task<Result> GetAsync<Result>(string endpoint)
			{
				var response = await _client.GetAsync (endpoint);
				response.EnsureSuccessStatusCode ();
				var jsonResponse = await response.Content.ReadAsStringAsync ();
				return JsonSerializer.Deserialize<Result>(jsonResponse)!;
			}

		}
	}
}
