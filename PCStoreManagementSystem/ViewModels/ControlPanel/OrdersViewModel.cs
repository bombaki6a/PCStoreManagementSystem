using System.Collections.ObjectModel;

using PCStoreManagementSystem.Views.SubPages;

using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;
using PCStoreManagementSystem.Models.Database.Interfaces;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.ControlPanel;

/// <summary>
/// The OrdersViewModel Page, shows all availible orders,
/// giving the option to add, cancel and accept an order.
/// </summary>
public partial class OrdersViewModel : ObservableObject
{
    private readonly IEmployee _currentEmployee;

    [ObservableProperty]
    private ObservableCollection<Order> _orders;

    [ObservableProperty]
    private Order _selectedOrder;

    [ObservableProperty]
    private string _searchText;

    public IEmployee CurrentEmployee { get => _currentEmployee; }

    public OrdersViewModel(IEmployee currentEmployee)
    {
        _currentEmployee = currentEmployee;
        Orders = new(Task.Run(() => DatabaseService<Order>.GetTableAsync()).Result);
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        SelectedOrder = null;

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            List<Order> orders = await DatabaseService<Order>.GetTableAsync();
            Orders = new(orders.Where(o => $"{o.Id - 0}" == SearchText));
        }
        else
        {
            Orders = new(await DatabaseService<Order>.GetTableAsync());
        }
    }

    [RelayCommand]
    private async Task AddOrderAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddOrderView));
    }

    [RelayCommand]
    private async Task EditOrderAsync()
    {
        if (SelectedOrder != null)
        {
            Dictionary<string, object> args = new() { { $"{nameof(Order)}", SelectedOrder} };
            await Shell.Current.GoToAsync(nameof(EditOrderView), args);
        }
        else
        {
            await Shell.Current.DisplayAlert("No order selected", "Please select and try again.", "Ok");
        }
    }

    [RelayCommand]
    private async Task CancelOrAcceptOrderAsync(bool isAccept)
    {
        if (SelectedOrder != null)
        {
            OrderHistory order = new()
            {
                Id = SelectedOrder.Id,
                CurrentEmployeeId = CurrentEmployee.Id,
                UserId = SelectedOrder.UserId,
                ProductId = SelectedOrder.ProductId,
                Date = SelectedOrder.Date,
                Quantity = SelectedOrder.Quantity,
                Accept = isAccept
            };

            Orders.Remove(SelectedOrder);
            await DatabaseService<Order>.RemoveColumnAsync(SelectedOrder.Id);
            await DatabaseService<OrderHistory>.AddColumnAsync(order);
        }
        else
        {
            await Shell.Current.DisplayAlert("No order selected", "Please select and try again.", "Ok");
        }
    }
}
