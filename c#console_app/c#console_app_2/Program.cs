using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace console_app {
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello!\n");
			string option = "A";
			var todo_list = new List<Tuple<string, string>>();
			while (option != "e")
			{
				Console.WriteLine("[s] See ToDo list\n[a] Add ToDo\n[r] Remove ToDo\n[e] Exit\n\nEnter option: ");
				option = Console.ReadLine();
				if (option == "s" || option == "S")
				{
					if (todo_list.Count == 0)
						Console.WriteLine("\nYour ToDo list is empty!\n");
					else
						for (int i = 0; i < todo_list.Count; i++)
						{
							Console.WriteLine($"{i + 1}) {todo_list[i].Item1}\n");
						}
				}
				else if (option == "a" || option == "A")
				{
					Console.WriteLine("\nEnter the activity name: ");
					string activity_name = Console.ReadLine();
					Console.WriteLine("\nEnter the activity description: ");
					string activity_description = Console.ReadLine();
					var activity = new Tuple<string, string>(activity_name, activity_description);
					todo_list.Add(activity);

					Console.WriteLine("\nThe activity has been added\n");
				}
				else if (option == "r" || option == "R")
				{
					Console.WriteLine("\nEnter the activity name: ");
					string activity_name = Console.ReadLine();
					foreach (var activity in todo_list)
					{
						if (activity.Item1 == activity_name)
						{
							todo_list.Remove(activity);
							Console.WriteLine("\nThe activity has been removed\n");
							break;
						}
					}
				}
				else if (option == "E") { option = "e"; }
				else Console.WriteLine("invalid option\n");
			}

		}
	}
}