using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starwars
{
	internal class Service
	{
		private Repo Repository;

		public Service (Repo repository)
		{
			this.Repository = repository;
		}

		public Tuple<Planet, Planet>? getStatistica (string statistic)
		{
			statistic = statistic.ToLower();
			switch (statistic)
			{
				case "population":
					return new Tuple<Planet, Planet>(
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getPopulation(), out int population) ? population : 0)
											.First(),
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getPopulation(), out int population) ? population : 0)
											.Last());
				case "diameter":
					return new Tuple<Planet, Planet>(
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getDiameter(), out int diameter) ? diameter : 0)
											.First(),
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getDiameter(), out int diameter) ? diameter : 0)
											.Last());
				case "surface water":
					return new Tuple<Planet, Planet>(
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getSurfaceWater(), out int surfaceWater) ? surfaceWater : 0)
											.First(),
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getSurfaceWater(), out int surfaceWater) ? surfaceWater : 0)
											.Last());
				default:
					return null;
			}
		}

		public IEnumerable<Planet> getPlanetList() => this.Repository.getPlanetList();

	}
}
