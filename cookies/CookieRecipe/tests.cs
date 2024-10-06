using CookieRecipe.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRecipe
{
	internal class Tests
	{
		public Tests()
		{
			this.test_all();
		}

		public void test_all ()
		{
			this.test_ingredient();
			this.test_recipe();
		}

		public void test_ingredient ()
		{
			Ingredient ingr = new Ingredient(1, "faina", "faina");

			if (ingr.getInstruction() != "faina")
				Console.WriteLine("Failed test!");
			if (ingr.getName() != "faina")
				Console.WriteLine("Failed test!");
			if (ingr.getId() != 1)
				Console.WriteLine("Failed test!");

			IngredientList ingr_list = new IngredientList();
			Ingredient ingr1 = ingr_list.getIngredient(1);
			Ingredient ingr2 = ingr_list.getIngredient(2);

			if (ingr1.getId() != 1)
				Console.WriteLine("Failed test!");
			if (ingr2.getId() != 2)
				Console.WriteLine("Failed test!");
			if (ingr1.getName() != "Oua")
				Console.WriteLine("Failed test!");
			if (ingr2.getName() != "Lapte")
				Console.WriteLine("Failed test!");
			List<int> list_int = new List<int> { 1, 2, 3 };
			List<Ingredient> ingr_list_test = IngredientList.getIngredientsBasedOnIds(ingr_list, list_int);

			var ingr3 = ingr_list_test[0];
			var ingr4 = ingr_list_test[1];
			var ingr5 = ingr_list_test[2];

			if (ingr3.getId() != 1)
				Console.WriteLine("Failed test!");
			if (ingr4.getId() != 2)
				Console.WriteLine("Failed test!");
			if (ingr5.getId() != 3)
				Console.WriteLine("Failed test!");
			if (ingr3.getName() != "Oua")
				Console.WriteLine("Failed test!");
			if (ingr4.getName() != "Lapte")
				Console.WriteLine("Failed test!");
			if (ingr5.getName() != "Faina")
				Console.WriteLine("Failed test!");
		}

		public void test_recipe ()
		{
			IngredientList ingr_list = new IngredientList();
			Recipe recipe = new Recipe(1, "1", IngredientList.getIngredientsBasedOnIds(ingr_list, new List<int> { 1, 2, 3 }));
			if (recipe.getId() != 1)
				Console.WriteLine("Failed test!");
			if (recipe.getName() != "1")
				Console.WriteLine("Failed test!");
			List<int> list_id = recipe.getIngredientsId();
			if (list_id[0] != 1 || list_id[1] != 2 || list_id[2] != 3)
				Console.WriteLine("Failed test!");
		}
	}
}
