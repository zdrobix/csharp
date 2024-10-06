using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameParser
{
	internal class Service
	{
		private Repo repo;
		public Service() 
		{
			this.repo = new Repo();
		}

		public void set_repo ( Repo _repo )
		{
			this.repo = _repo;
		}

		public string display_games ()
		{
			return this.repo.display_games();
		}
	}
}
