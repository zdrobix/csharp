using CookieRecipe.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRecipe
{
	internal class Ui
	{
		private Service service;

		public Ui ( Service _service )
		{
			this.service = _service;
		}

		public void Run ()
		{
			while (true)
			{
				List<Recipe> recipes = this.service.getRecipes();
				if (recipes.Count != 0)
				{
					Console.WriteLine("Existing recipes: " + recipes.Count);
					foreach (var recipe in recipes)
						recipe.print_recipe();
				}

				Console.Write("0 to exit!\n");
				bool exit = false;

				this.service.getIngredientList().displayIngredients();
				List<int> ingredients_ids = new List<int>();
				while (true)
				{
					Console.WriteLine("Select: ");
					int option;
					if (!int.TryParse(Console.ReadLine(), out option))
					{
						Console.Write("The ingredients were selected!\n");
						break;
					}
					if (option == 0)
					{
						exit = true;
						break;
					}
					ingredients_ids.Add(option);
				}

				if (exit)
					break;

				Console.WriteLine("Enter an id for your recipe: ");
				int id;
				while ( !int.TryParse(Console.ReadLine(), out id))
				{
					Console.WriteLine("Invalid id. Must be an integer!");
				}
				Console.WriteLine("Enter a name for your recipe: ");
				string name = Console.ReadLine();

				if (this.service.addRecipe(id, name, ingredients_ids))
					Console.WriteLine($"The recipe for {name} was added succesfully!");
				else Console.WriteLine($"The recipe for {name} was not added succesfully!");

				Console.WriteLine("Wish to exit? [Y/N]");
				string answer = Console.ReadLine();
				if (answer == "Y" || answer == "y")
					break;
			}
		}
	}
}
