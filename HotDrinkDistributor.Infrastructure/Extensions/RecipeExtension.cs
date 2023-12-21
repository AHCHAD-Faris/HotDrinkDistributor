using HotDrinkDistributor.Domain.Models;
using HotDrinkDistributor.Infrastructure.Models;

namespace HotDrinkDistributor.Infrastructure.Extensions
{
    public static class RecipeExtensions
    {
        public static Recipe ToDomainRecipe(this RecipeInfra recipeInfra) =>
            new()
            {
                Id = recipeInfra.Id,
                Name = recipeInfra.RecipeName,
                Ingredients = recipeInfra.Ingredients.Select(ToDomainIngredient).ToList(),
            };

        private static Ingredient ToDomainIngredient(this IngredientInfra ingredientInfra) =>
           new()
           {
               Product = new Product
               {
                   Name = ingredientInfra.Product.Name,
                   Price = ingredientInfra.Product.Price
               },
               Quantity = ingredientInfra.Quantity
           };
    }
}
