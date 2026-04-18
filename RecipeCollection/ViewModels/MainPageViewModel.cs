using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeCollection.Views;
using System.Collections.ObjectModel;

namespace RecipeCollection.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> categories;

        public MainPageViewModel() 
        {
            Categories = new ObservableCollection<string>();
            Categories.Add("Middag");
            Categories.Add("Desert");
            Categories.Add("Övrigt");
        }

        [RelayCommand]
        private async Task TapCategory()
        {
            await Shell.Current.GoToAsync(nameof(CategoryPage));
        }
    }
}
