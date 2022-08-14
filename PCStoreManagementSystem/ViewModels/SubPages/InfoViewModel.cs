using PCStoreManagementSystem.Models.Database.Tables;

using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.SubPages;

/// <summary>
/// The InfoViewModel, binded to InfoView page, giving all the information of a given order.
/// </summary>
[QueryProperty(nameof(OrderHistory), "OrderHistory")]
public partial class InfoViewModel : BaseViewModel
{
    [ObservableProperty]
    private OrderHistory _orderHistory;
}
