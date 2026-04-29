using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    [QueryProperty("CategoryTitle", "CategoryTitle")]
    public partial class CategoryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> recipes;
        [ObservableProperty]
        private string categoryTitle;
        [ObservableProperty]
        private string recipeToAdd;

        public CategoryPageViewModel()
        {
            Recipes = new ObservableCollection<string>();
            Recipes.Add("Ost- & Skinkpaj");
            Recipes.Add("Pannkakor");
        }

        [RelayCommand]
        private async Task TapRecipe(string recipeTitle)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?RecipeTitle={Uri.EscapeDataString(recipeTitle)}");
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private void AddRecipe()
        {
            Recipes.Add(RecipeToAdd);
        }

        [RelayCommand]
        private void RemoveRecipe()
        {
            Recipes.Remove(RecipeToAdd);
        }
    }
}
