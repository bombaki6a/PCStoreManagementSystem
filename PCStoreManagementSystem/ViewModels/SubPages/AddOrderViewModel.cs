using System.Collections.ObjectModel;

using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.SubPages;

/// <summary>
/// The AddOrderViewModel, binded to AddOrderView page, allows orders to be added.
/// </summary>
public partial class AddOrderViewModel : BaseViewModel
{
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

    [ObservableProperty]
    private int _quantity = 1;

    public AddOrderViewModel()
    {
        Users = new(Task.Run(() => DatabaseService<User>.GetTableAsync()).Result);
        Products = new(Task.Run(() => DatabaseService<Product>.GetTableAsync()).Result);

        SelectedUser = GetItemIfExist(Users);
        SelectedProduct = GetItemIfExist(Products);
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
    private async Task AddAsync()
    {
        if ((SelectedUser != null) && (SelectedProduct != null))
        {
            Order order = new() { UserId = SelectedUser.Id, ProductId = SelectedProduct.Id, Quantity = Quantity, Date = DateTime.Now };

            await DatabaseService<Order>.AddColumnAsync(order);
            await Shell.Current.DisplayAlert("Order added successfully", "Press Ok and return to home", "Ok");

            BackCommand.Execute(null);
        }
        else
        {
            await Shell.Current.DisplayAlert("No user or product selected", "Press Ok and return to home", "Ok");
        }
    }
}
