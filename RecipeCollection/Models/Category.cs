
namespace RecipeCollection.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
