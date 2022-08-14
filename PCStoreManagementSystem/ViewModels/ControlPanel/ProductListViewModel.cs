using System.Collections.ObjectModel;

using PCStoreManagementSystem.Views.SubPages;

using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.ControlPanel;

/// <summary>
/// The ProductListViewModel, binded to ProductListView page
/// and implements the standart CRUD operations to the product list.
/// </summary>
public partial class ProductListViewModel : ObservableObject
{
    [ObservableProperty]
    private Product _selectedProduct;
    [ObservableProperty]
    private ObservableCollection<Product> _products;

    [ObservableProperty]
    private string _searchText;

    public ProductListViewModel()
    {
        Products = new(Task.Run(async () => await DatabaseService<Product>.GetTableAsync()).Result);
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        SelectedProduct = null;

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            List<Product> products = await DatabaseService<Product>.GetTableAsync();
            Products = new(products.Where(u => u.Name.Contains(SearchText) ||
            u.Model.Contains(SearchText) ||
            u.Manufacturer.ToString().Contains(SearchText)));
        }
        else
        {
            Products = new(await DatabaseService<Product>.GetTableAsync());
        }
    }

    [RelayCommand]
    private async Task EditProductAsync()
    {
        if (SelectedProduct != null)
        {
            Dictionary<string, object> args = new() { { $"{nameof(Product)}", SelectedProduct } };
            await Shell.Current.GoToAsync($"{nameof(EditProductView)}", args);
        }
        else
        {
            await Shell.Current.DisplayAlert("No product selected", "Please select and try again.", "Ok");
        }
    }

    [RelayCommand]
    private async Task RemoveProductAsync()
    {
        if (SelectedProduct != null)
        {
            await DatabaseService<Product>.RemoveColumnAsync(SelectedProduct.Id);
            Products.Remove(SelectedProduct);

            SelectedProduct = null;
        }
        else
        {
            await Shell.Current.DisplayAlert("No product selected", "Please select and try again.", "Ok");
        } 
    }

    [RelayCommand]
    private async Task AddProductAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddProductView));
    }
}
