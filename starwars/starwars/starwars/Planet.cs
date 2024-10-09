using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starwars
{
	internal class Planet
	{
		private string Name;
		private string Diameter;
		private string SurfaceWater;
		private string Population;

		public Planet(string name, string diameter, string surfaceWater, string population)
		{
			this.Name = name; 
			this.Diameter = diameter;
			this.SurfaceWater = surfaceWater;
			this.Population = population;
		}

		public string getName() => this.Name;
		public string getDiameter() => this.Diameter;
		public string getSurfaceWater() => this.SurfaceWater;
		public string getPopulation() => this.Population;
	}
}
