using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll
{
	internal class Repo
	{
		private int number_to_guess;

		public int get_number() => this.number_to_guess;

		public Repo ()
		{
			Random random = new Random();
			this.number_to_guess = random.Next(1, 7);
		}
	}
}
