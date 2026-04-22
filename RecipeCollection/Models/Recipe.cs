
namespace RecipeCollection.Models
{
    internal class Recipe
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
