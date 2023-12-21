namespace HotDrinkDistributor.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public decimal Price => Ingredients?.Sum(ingredient => (ingredient.Product?.Price ?? 0) * ingredient.Quantity) ?? 0;
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }  
}
