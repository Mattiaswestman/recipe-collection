using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RecipeCollection.Models;
using RecipeCollection.Services;
using RecipeCollection.Views;

namespace RecipeCollection.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> categories;
        [ObservableProperty]
        private string currentCategory;

        private RecipeCollectionDbContext database;

        public MainPageViewModel(RecipeCollectionDbContext database) 
        {
            this.database = database;
            Categories = new ObservableCollection<string>();
            UpdateCategoriesAsync();
        }

        [RelayCommand]
        private async Task TapCategory(string categoryTitle)
        {
            await Shell.Current.GoToAsync($"{nameof(CategoryPage)}?CategoryTitle={Uri.EscapeDataString(categoryTitle)}");
        }

        [RelayCommand]
        private async Task AddCategoryAsync()
        {
            var newCategory = new Category();
            newCategory.Id = Random.Shared.Next(10000, 99999);
            newCategory.Title = CurrentCategory;

            database.Categories.Add(newCategory);
            await database.SaveChangesAsync();
            await UpdateCategoriesAsync();
        }

        [RelayCommand]
        private async Task RemoveCategoryAsync()
        {
            var category = await database.Categories.FirstOrDefaultAsync(c => c.Title == CurrentCategory);
            if (category != null)
            {
                database.Categories.Remove(category);
                await database.SaveChangesAsync();
                await UpdateCategoriesAsync();
            }
        }

        private async Task UpdateCategoriesAsync()
        {
            Categories.Clear();
            var categories = await database.Categories
                .OrderBy(c => c.Title.Substring(0, 1))
                .ToListAsync();

            foreach (var category in categories)
            {
                Categories.Add(category.Title);
            }
        }
    }
}
