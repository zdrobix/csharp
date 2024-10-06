using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameParser
{
	internal class Tests
	{
		public Tests()
		{
			this.test_exception();
		}

		private void test_exception()
		{
			Service service1 = new Service();

			try
			{
				service1.set_repo(new Repo("NONEXISTENTFILE.JSON"));
				Console.WriteLine("\nFailed tests!");
			} catch (FileNotFoundException e) { }

			try
			{
				service1.set_repo(new Repo(""));
				Console.WriteLine("\nFailed tests!");
			}
			catch (ArgumentException e) { }

			try
			{
				service1.set_repo(new Repo("gamesInvalidFormat.json"));
				Console.WriteLine("\nFailed tests!");
			}
			catch (InvalidOperationException e) { }

			try
			{
				service1.set_repo(new Repo("games.json"));
			}
			catch (Exception e) {
				Console.WriteLine("\nFailed tests!");
			}
		}

		
	}
}
