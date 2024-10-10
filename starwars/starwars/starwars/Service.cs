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
											.OrderBy(planet => int.TryParse(planet.getPopulation(), out int population) ? population : int.MaxValue)
											.First(),
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getPopulation(), out int population) ? population : int.MinValue)
											.Last());
				case "diameter":
					return new Tuple<Planet, Planet>(
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getDiameter(), out int diameter) ? diameter : int.MaxValue)
											.First(),
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getDiameter(), out int diameter) ? diameter : int.MinValue)
											.Last());
				case "surface water":
				case "surfacewater":
					return new Tuple<Planet, Planet>(
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getSurfaceWater(), out int surfaceWater) ? surfaceWater : int.MaxValue)
											.First(),
						this.Repository.getPlanetList()
											.Select(planet => planet)
											.OrderBy(planet => int.TryParse(planet.getSurfaceWater(), out int surfaceWater) ? surfaceWater : int.MinValue)
											.Last());
				default:
					throw new ArgumentException("Statistic can only be of type: diameter, population and surface water");
			}
		}

		public IEnumerable<Planet> getPlanetList() => this.Repository.getPlanetList();

	}
}
