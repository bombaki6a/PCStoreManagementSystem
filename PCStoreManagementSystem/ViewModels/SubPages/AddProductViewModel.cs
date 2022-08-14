using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.SubPages;

/// <summary>
/// The AddProductViewModel, binded to AddProductView page, allows products to be added.
/// </summary>
public partial class AddProductViewModel : BaseViewModel
{
    [ObservableProperty]
    private Product _product = new() { Manufacturer = 0, Type = 0 };

    private static bool IsAnyNullOrEmpty(object product)
    {
        return product.GetType()
            .GetProperties()
            .Where(pt => pt.PropertyType == typeof(string))
            .Select(v => (string)v.GetValue(product))
            .Any(value => string.IsNullOrWhiteSpace(value));
    }

    [RelayCommand]
    private async Task AddAsync()
    {
        if (IsAnyNullOrEmpty(Product))
        {
            await Shell.Current.DisplayAlert("There is an empty field", "Please fill it out and try again.", "Ok");
        }
        else
        {
            await DatabaseService<Product>.AddColumnAsync(Product);
            await Shell.Current.DisplayAlert("Product added successfully", "Press Ok and return to the product list", "Ok");

            BackCommand.Execute(null);
        }
    }
}
