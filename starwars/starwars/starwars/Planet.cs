using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starwars
{
	internal class Planet
	{
		//Class for the Planet object. 
		private string Name;
		private string Diameter;
		private string? SurfaceWater;
		private string? Population;

		public Planet(string name, string diameter, string surfaceWater, string population)
		{
			this.Name = name; 
			this.Diameter = diameter;
			this.SurfaceWater = surfaceWater;
			this.Population = population;
		}

		public string getName() => this.Name;
		public string getDiameter() => this.Diameter;
		public string? getSurfaceWater() => this.SurfaceWater;
		public string? getPopulation() => this.Population;

		public string? getStatistic(string statistic)
		{
			switch (statistic)
			{
				case "population":
					return this.getPopulation();
				case "diameter":
					return this.getDiameter();
				case "surface water":
					return this.getSurfaceWater();
				case "surfacewater":
					return this.getSurfaceWater();
				default:
					return null;
			}
		}

		public static explicit operator Planet(Result result)
		{
			return new Planet(result.name, result.diameter, result.surface_water, result.population);
		}
	}
}
