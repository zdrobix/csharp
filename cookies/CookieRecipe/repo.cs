using CookieRecipe.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRecipe
{
	internal class Repo
	{
		private string filename = "C:\\Alex Zdroba\\c# projects\\cookies\\CookieRecipe\\input\\recipes.txt";
		private List<Recipe> recipe_list;
		private IngredientList ingredient_list;

		public Repo ()
		{
			this.ingredient_list = new IngredientList ();
			this.loadRecipes();
		
		}

		public void loadRecipes()
		{
			this.recipe_list = new List<Recipe>();
			using (StreamReader sr = new StreamReader(this.filename))
			{
				string id, name, ingredients;
				while ((id = sr.ReadLine()) != null)
				{
					name = sr.ReadLine();
					ingredients = sr.ReadLine();

					var ingredients_ids = ingredients.Split(',').Select(int.Parse).ToList();

					List<Ingredient> recipe_ingredient_list = IngredientList.getIngredientsBasedOnIds(this.ingredient_list, ingredients_ids);

					this.recipe_list.Add(new Recipe(int.Parse(id), name, recipe_ingredient_list));
				}
			}
		}

		public void saveRecipes()
		{
			using (StreamWriter sw = new StreamWriter(this.filename))
			{
				sw.WriteLine(string.Join('\n', this.recipe_list.Select(recipe => $"{recipe.getId()}\n{recipe.getName()}\n{string.Join(',', recipe.getIngredientsId())}")));
			}
		}

		public void addRecipe(Recipe recipe)
		{
			this.recipe_list.Add(recipe);
			this.saveRecipes();
		}

		public List<Recipe> getRecipes() => this.recipe_list;

		public IngredientList getIngredientList() => this.ingredient_list;

		public Recipe getRecipe ( int id) => 
			this.recipe_list.First(recipe => recipe.getId() == id);
		
	}
}
