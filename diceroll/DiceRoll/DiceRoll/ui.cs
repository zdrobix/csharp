using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll
{
	internal class Ui
	{
		private Service service;
		
		public Ui (Service _service)
		{
			this.service = _service;
		}

		public void run ()
		{
			int tries = 3;
			Console.WriteLine("The number has been generated. Try to guess it in 3 tries!");
			while (tries > 0)
			{
				int guessed;
				Console.Write("Enter number: ");
				if (!int.TryParse(Console.ReadLine(), out guessed))
					continue;
				if (guessed < 1 || guessed > 6)
					continue;
				if (this.service.guess_number(guessed))
				{
					Console.WriteLine("You guessed the number!");
					break;
				} else
				{
					Console.WriteLine("Nope..");
					tries--;
				}
			}
		}
	}
}
