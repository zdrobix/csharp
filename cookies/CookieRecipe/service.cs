using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieRecipe.domain;

namespace CookieRecipe
{
	internal class Service
	{
		private Repo repo;

		public Service (Repo _repo)
		{
			this.repo = _repo;
		}

		public bool addRecipe (int id, string name, List<int> ingredients_ids)
		{
			if (this.repo.getRecipe(id) != null)
				return false;
			this.repo.addRecipe(new Recipe(id, name, IngredientList.getIngredientsBasedOnIds(this.repo.getIngredientList(), ingredients_ids)));
			return true;
		}

		public List<Recipe> getRecipes () =>
			 this.repo.getRecipes();

		public IngredientList getIngredientList() =>
			 this.repo.getIngredientList();
	}
}
