using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace starwars
{
	internal class ReadPlanets
	{
		private IApiDataReader Reader;

		public ReadPlanets(IApiDataReader reader)
		{
			this.Reader = reader;
		}

		public async Task<IEnumerable<Planet>> InitializeAsync()
		{
			var jsonData = await Reader.Read("https://swapi.dev/", "api/planets"); 
			var root = JsonSerializer.Deserialize<Root>(jsonData);
			return root!.results
				.Select(res => (Planet)res);
		}
	}
}
