using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace starwars
{
	internal class Repo
	{
		private List<Planet> PlanetList;
		private string BaseAddress;
		private string RequestUri;

		public Repo (string baseAddress, string requestUri)
		{
			this.BaseAddress = baseAddress;
			this.RequestUri = requestUri;
			this.PlanetList = new List<Planet> ();
		}

		private async Task InitializeAsync()
		{
			IApiDataReader apiDataReader = new ApiDataReader();
			var jsonData = await apiDataReader.Read(this.BaseAddress, this.RequestUri); Console.WriteLine(jsonData);
			var root = JsonSerializer.Deserialize<Root>(jsonData);
			root.results
				.Select(res => new Planet(res.name, res.diameter, res.surface_water, res.population))
				.ToList();
		}

		public static async Task<Repo> CreateAsync(string baseAddress, string requestUri)
		{
			var repo = new Repo(baseAddress, requestUri);
			await repo.InitializeAsync();
			return repo;
		}

		public IEnumerable<Planet> getPlanetList() => this.PlanetList;
	}
}
