namespace HotDrinkDistributor.Infrastructure.Models
{
    public class RecipeInfra
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public List<IngredientInfra> Ingredients { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class IngredientInfra
    {
        public int Id { get; set; }
        public ProductInfra Product { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductInfra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
