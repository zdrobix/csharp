using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketdata
{
	public class Ui
	{
		private Repo repo;

		public Ui(Repo repo_) {
			this.repo = repo_;
		}	
		public void Run()
		{
			Console.Write("Write the path of the directory, or leave empty to use default: ");
			var path = @"" + Console.ReadLine();
			if ( path == @"")
				path = @"Q:\info\c# projects\ticketdata\ticketdata\ticketdata\input";
			this.repo.loadData(path);
			Console.Write("Tickets loaded, press any key to print: ");
			Console.ReadKey();
			Console.WriteLine("\n\n" + this.repo.listTickets());
		}
	}
}
