using HotDrinkDistributor.Domain.Ports;
using HotDrinkDistributor.Domain.Models;

namespace HotDrinkDistributor.Infrastructure.Services
{
    public class HotDrinkService : IHotDrinkService
    {
        private readonly IHotDrinkRepository _hotDrinkRepository;

        public HotDrinkService(IHotDrinkRepository hotDrinkRepository) 
            => _hotDrinkRepository = hotDrinkRepository;

        public Recipe GetRecipe(int id) 
            => _hotDrinkRepository.GetRecipe(id) 
                ?? throw new InvalidOperationException("Recipe Not Found");

        public IEnumerable<Recipe> GetAllRecipes() => _hotDrinkRepository.GetAllRecipes();

        //Normally, IDs are auto generated in the database, with one to many relations, no need to read all data
        //But to make this work easily and fast (mock), I made it this way
        public void AddRecipe(Recipe recipe)
        {
            var allRecipes = GetAllRecipes();
            if (allRecipes.Any(existingRecipe => existingRecipe.Name == recipe.Name))
            {
                throw new InvalidOperationException("Recipe name must be unique.");
            }
            if (recipe.Ingredients == null || recipe.Ingredients.Count == 0)
            {
                throw new InvalidOperationException("A recipe must have ingredients.");
            }

            recipe.Id = allRecipes.Any() ? allRecipes.Select(r => r.Id).Max() + 1 : 1;

            _hotDrinkRepository.AddRecipe(recipe);
        }

        public void UpdateRecipe(Recipe modifiedRecipe)
        {
            Recipe recipeToModify = GetRecipe(modifiedRecipe.Id);
           
            recipeToModify.Name = modifiedRecipe.Name;
            recipeToModify.Ingredients = modifiedRecipe.Ingredients;
            _hotDrinkRepository.UpdateRecipe(recipeToModify);
        }

        public void DeleteRecipe(int recipeId)
        {
            Recipe recipeToRemove = GetRecipe(recipeId);
         
            _hotDrinkRepository.DeleteRecipe(recipeToRemove);
        }
    }
}
