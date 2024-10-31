using System;
namespace passwordgen
{
	internal class Application {

		public static void Main(string[] args)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(PasswordGenerator.Generate(5, 10, false));
			}
			Console.ReadKey();
		}
	}
}




