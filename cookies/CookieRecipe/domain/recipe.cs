using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRecipe.domain
{
	internal class Recipe
	{
		private int id;
		private string name;
		private List<Ingredient> ingredients;

		public Recipe(int _id, string _name, List<Ingredient> _ingredients)
		{
			this.id = _id;
			this.name = _name;
			this.ingredients = _ingredients;
		}

		public Recipe(int _id, string _name)
		{
			this.id = _id;
			this.name = _name;
			this.ingredients = new List<Ingredient>();
		}

		public void print_recipe()
		{
			Console.Write($"\n****{this.id}****\n{this.name}\n\n");
			Console.Write(String.Join("\n", this.ingredients.Select(ingr => ingr.getInstruction())));
			Console.Write("\n");
		}

		public int getId() => this.id;
		public string getName() => this.name;
		public List<int> getIngredientsId() =>
			this.ingredients.Select(ingredients => ingredients.getId()).ToList();
		
	}
}
