using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.SubPages;

/// <summary>
/// The EditProductViewModel, binded to EditProductView page, allows editing of a product.
/// </summary>
[QueryProperty(nameof(Product), nameof(Product))]
public partial class EditProductViewModel : BaseViewModel
{
    [ObservableProperty]
    private Product _product;

    [RelayCommand]
    private async Task EditAsync()
    {
        await DatabaseService<Product>.UpdateColumnAsync(Product);
        await Shell.Current.DisplayAlert("Edit success", "Press Ok and return to the product list", "Ok");

        BackCommand.Execute(null);
    }
}
