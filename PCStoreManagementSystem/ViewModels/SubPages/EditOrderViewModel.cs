using System.Collections.ObjectModel;

using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.SubPages;

/// <summary>
/// The EditOrderViewModel, binded to EditOrderView page, allows editing of an order.
/// </summary>
[QueryProperty(nameof(Order), nameof(Order))]
public partial class EditOrderViewModel : BaseViewModel
{
    [ObservableProperty]
    private Order _order;

    [ObservableProperty]
    private ObservableCollection<User> _users;
    [ObservableProperty]
    private ObservableCollection<Product> _products;

    [ObservableProperty]
    private User _selectedUser;
    [ObservableProperty]
    private Product _selectedProduct;

    [ObservableProperty]
    private string _userFiltering;
    [ObservableProperty]
    private string _productFiltering;

    public EditOrderViewModel()
    {
        Users = new(Task.Run(async () => await DatabaseService<User>.GetTableAsync()).Result);
        Products = new(Task.Run(async () => await DatabaseService<Product>.GetTableAsync()).Result);
    }

    partial void OnOrderChanged(Order value)
    {
        SelectedUser = Users.Where(u => u.Id == value.UserId).ToList()[0];
        SelectedProduct = Products.Where(p => p.Id == value.ProductId).ToList()[0];
    }

    [RelayCommand]
    private async Task UserFilteringAsync()
    {
        if (UserFiltering != default)
        {
            List<User> users = await DatabaseService<User>.GetTableAsync();
            users = users.Where(u => u.Email.Contains(UserFiltering) || u.FullName.Contains(UserFiltering)).ToList();

            Users = new(users);
            SelectedUser = GetItemIfExist(Users);
        }
        else
        {
            Users = new(await DatabaseService<User>.GetTableAsync());
            SelectedUser = GetItemIfExist(Users);
        }
    }

    [RelayCommand]
    private async Task ProductFilteringAsync()
    {
        if (ProductFiltering != default)
        {
            List<Product> products = await DatabaseService<Product>.GetTableAsync();
            products = products.Where(p => p.Name.Contains(ProductFiltering) ||
            p.Model.Contains(ProductFiltering) ||
            p.Manufacturer.ToString().Contains(ProductFiltering)).ToList();

            Products = new(products);
            SelectedProduct = GetItemIfExist(Products);
        }
        else
        {
            Products = new(await DatabaseService<Product>.GetTableAsync());
            SelectedProduct = GetItemIfExist(Products);
        }
    }

    [RelayCommand]
    private async Task EditAsync()
    {
        Order.UserId = SelectedUser.Id;
        Order.ProductId = SelectedProduct.Id;

        await DatabaseService<Order>.UpdateColumnAsync(Order);
        await Shell.Current.DisplayAlert("Edit success", "Press Ok and return to the order list", "Ok");

        BackCommand.Execute(null);
    }
}
