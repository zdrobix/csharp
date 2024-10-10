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
			Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", "Name", "Diameter", "Surface Water", "Population\n");
			foreach (var planet in this.Service_.getPlanetList())
			{
				Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", 
					planet.getName(), 
					planet.getDiameter(), 
					planet.getSurfaceWater(), 
					planet.getPopulation());
			}
			Console.WriteLine($"\nPlease enter a statistic: (diameter/ surface water/ population)\n");
			string? input = Console.ReadLine();
			if (input != null)
			{
				try
				{
					var result = this.Service_.getStatistica(input.ToLower());
					Console.WriteLine($"\nMin value for {input} is: {result.Item1.getName()}, with the {input} of {result.Item1.getStatistic(input.ToLower())}\n" +
										$"Max value for {input} is: {result.Item2.getName()}, with the {input} of {result.Item2.getStatistic(input.ToLower())}");
				}
				catch (ArgumentException e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}
	}
}
