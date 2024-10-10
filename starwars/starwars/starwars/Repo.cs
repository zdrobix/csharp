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
		private IEnumerable<Planet> PlanetList;
		private Repo(IEnumerable<Planet> planetList)
		{
			this.PlanetList = planetList;
		}
		public static async Task<Repo> CreateAsync()
		{
			var reader = new ReadPlanets(new ApiDataReader());
			var planets = await reader.InitializeAsync();
			return new Repo(planets);
		}

		public IEnumerable<Planet> getPlanetList() => this.PlanetList;
	}
}
