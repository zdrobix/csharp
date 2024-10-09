using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starwars
{
	internal class Ui
	{
		private Service Service_;
		public Ui(Service service_) 
		{ 
			this.Service_ = service_;
		}

		public void Run()
		{
			Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", "Name", "Diameter", "Surface Water", "Population");
			foreach (var planet in this.Service_.getPlanetList())
			{
				Console.WriteLine("{1,-15} {1,-15} {1,-15} {1-15}", 
					planet.getName, 
					planet.getDiameter, 
					planet.getSurfaceWater, 
					planet.getPopulation);
			}
		}
	}
}
