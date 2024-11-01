using System;

namespace passwordgen;

internal class App { 
	public static void Main(string[] args)
	{
		PasswordGenerator passwordGenerator = new PasswordGenerator(new Random());
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine(passwordGenerator.Generate(5, 10, false));
		}
		Console.ReadKey();
	}
}


