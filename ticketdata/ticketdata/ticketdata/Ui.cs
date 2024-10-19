using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketdata
{
	public class Ui
	{
		public Ui() { }	
		public void Run()
		{
			Console.Write("Write the path of the directory, or leave empty to use default: ");
			var path = @"" + Console.ReadLine();
			if ( path == @"")
				path = @"Q:\info\c# projects\ticketdata\ticketdata\ticketdata\input";
			new ReadData(path).Read();
		}
	}
}
