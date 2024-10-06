using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameParser
{
	internal class Ui
	{
		private Service service;

		public Ui(Service _service)
		{
			this.service = _service;
		}

		public void Run ()
		{
			while (true)
			{
				Console.Write("\nEnter the name of the file you want to read: ");
				string filename = Console.ReadLine();

				try
				{
					Repo repo = new Repo(filename);
					this.service.set_repo(repo);
					Console.Write(this.service.display_games());
					break;
				} catch (FileNotFoundException e)
				{
					Console.Write("\nThe file you are trying to open doesn't exist.\n" + e.Message);
				} catch (ArgumentException e)
				{
					Console.Write("\nInvalid file name!\n" + e.Message);
				} catch (InvalidOperationException e)
				{
					Console.Write("\nThe file you are trying to open doesn't contain valid input.\n" + e.Message);
				}
					

			}
		
		}
	}
}
