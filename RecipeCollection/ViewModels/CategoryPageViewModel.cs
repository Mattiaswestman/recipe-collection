using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class CategoryPageViewModel : ObservableObject
    {
        public CategoryPageViewModel()
        {
        }

        [RelayCommand]
        private async Task TapRecipe()
        {
            await Shell.Current.GoToAsync(nameof(RecipePage));
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
