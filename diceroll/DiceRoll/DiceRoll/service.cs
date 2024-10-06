using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll
{
	internal class Service
	{
		private Repo repo;

		public Service(Repo _repo)
		{
			this.repo = _repo;
		}

		public bool guess_number (int nr)
		{
			return nr == this.repo.get_number();
		}
	}
}
