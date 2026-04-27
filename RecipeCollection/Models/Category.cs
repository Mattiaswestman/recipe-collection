
namespace RecipeCollection.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
