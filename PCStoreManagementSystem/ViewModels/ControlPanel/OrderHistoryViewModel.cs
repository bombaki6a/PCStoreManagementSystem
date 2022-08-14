using System.Collections.ObjectModel;

using PCStoreManagementSystem.Views.SubPages;

using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.ControlPanel;

/// <summary>
/// The OrderHistoryViewModel is bound to the OrderView page,
/// giving information about the orders.
/// </summary>
public partial class OrderHistoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<OrderHistory> _orderHistory;

    [ObservableProperty]
    private OrderHistory _selectedOrderHistory;

    [ObservableProperty]
    private string _searchText;

    public OrderHistoryViewModel()
    {
        OrderHistory = new(Task.Run(async () => await DatabaseService<OrderHistory>.GetTableAsync()).Result);
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        SelectedOrderHistory = null;

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            List<OrderHistory> orderHistory = await DatabaseService<OrderHistory>.GetTableAsync();
            OrderHistory = new(orderHistory.Where(o => $"{o.Id - 0}" == SearchText));
        }
        else
        {
            OrderHistory = new(await DatabaseService<OrderHistory>.GetTableAsync());
        }
    }

    [RelayCommand]
    private async Task MoreInfoAsync()
    {
        if (SelectedOrderHistory != null)
        {
            Dictionary<string, object> args = new() { { $"{nameof(OrderHistory)}", SelectedOrderHistory } };
            await Shell.Current.GoToAsync(nameof(InfoView), args);
        }
        else
        {
            await Shell.Current.DisplayAlert("No order selected", "Please select and try again.", "Ok");
        }
    }
}
