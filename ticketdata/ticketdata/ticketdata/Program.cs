using System;

namespace ticketdata
{
	internal class program()
	{	
		public static void Main()
		{
			new Ui(
				new Repo()
				).Run();
		}
	}
}