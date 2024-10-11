using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starwars
{
	internal class ApiDataReader : IApiDataReader
	{
		//Class for the api, that implements the api data reader interface.
		//A method that extracts the data from the base address, and returns the result as a string
		public async Task<string> Read(string baseAddress, string requestUri)
		{
			using HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(baseAddress);
			var response = await client.GetAsync(requestUri);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}
	}
}
