using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class RecipePageViewModel : ObservableObject
    {
        public RecipePageViewModel()
        {
        }

        [RelayCommand]
        private async Task TapReturn()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
