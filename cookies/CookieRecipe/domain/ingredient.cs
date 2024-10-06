using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CookieRecipe.domain
{
	public class Ingredient
	{
		private int id;
		private string name;
		private string instruction;

		public Ingredient ( int _id, string _name, string _instruction)
		{
			this.id = _id;
			this.name = _name;
			this.instruction = _instruction;
		}

		public int getId() => this.id;
		public string getName() => this.name;
		public string getInstruction() => this.instruction;
	}

	public class IngredientList
	{
		private string filename = "C:\\Alex Zdroba\\c# projects\\cookies\\CookieRecipe\\input\\ingredients.txt";
		private List<Ingredient> ingredient_list;

		public IngredientList ()
		{
			this.ingredient_list = new List<Ingredient> ();

			using (StreamReader sr = new StreamReader(this.filename))
			{
				string id, name, instruction;
				while ((id = sr.ReadLine()) != null)
				{
					name = sr.ReadLine();
					instruction = sr.ReadLine();

					if ( name != null && instruction != null && id != null)
						this.ingredient_list.Add(new Ingredient(int.Parse(id), name, instruction));
				}
			}
		}

		public Ingredient getIngredient (int id) =>
			this.ingredient_list.First(ingr => ingr.getId() == id);
		

		public static List<Ingredient> getIngredientsBasedOnIds (IngredientList ingredients,List<int> ingredients_ids) =>
			ingredients_ids.Select(id => ingredients.getIngredient(id)).ToList();

		public void displayIngredients()
		{
			Console.Write(String.Join("\n", this.ingredient_list.Select(ingr => $"{ingr.getId()}. {ingr.getName()}")));
			Console.Write("/n/n");
		}
	}
}
