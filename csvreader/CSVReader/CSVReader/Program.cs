using csvread.read;
using csvread.data;
using System;

namespace csvread
{
	public class App()
	{
		static void Main(String[] args)
		{
			CSVReader reader = new CSVReader("C:\\Alex Zdroba\\c# projects\\csvreader\\CSVReader\\CSVReader\\sampleData.csv");
			CSVData data = reader.read();
			Console.WriteLine("The data has been read!");
			Console.WriteLine(data.stringData());
			Console.ReadKey();
		}
	}
}