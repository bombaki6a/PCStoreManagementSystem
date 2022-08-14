using PCStoreManagementSystem.Views;
using PCStoreManagementSystem.Views.SubPages;
using PCStoreManagementSystem.Views.ControlPanel;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels;

/// <summary>
///  AppShellViewModel, binded to AppShell to able to use commands.
/// </summary>
public partial class AppShellViewModel : ObservableObject
{
    public AppShellViewModel()
    {
        // User Routing
        Routing.RegisterRoute(nameof(UserListView), typeof(UserListView));
        Routing.RegisterRoute(nameof(AddUserView), typeof(AddUserView));
        Routing.RegisterRoute(nameof(EditUserView), typeof(EditUserView));

        // Product Routing
        Routing.RegisterRoute(nameof(ProductListView), typeof(ProductListView));
        Routing.RegisterRoute(nameof(AddProductView), typeof(AddProductView));
        Routing.RegisterRoute(nameof(EditProductView), typeof(EditProductView));

        // Order Routing
        Routing.RegisterRoute(nameof(OrdersView), typeof(OrdersView));
        Routing.RegisterRoute(nameof(AddOrderView), typeof(AddOrderView));
        Routing.RegisterRoute(nameof(EditOrderView), typeof(EditOrderView));

        // Info Routing
        Routing.RegisterRoute(nameof(OrderHistoryView), typeof(OrderHistoryView));
        Routing.RegisterRoute(nameof(InfoView), typeof(InfoView));
    }

    [RelayCommand]
    private async Task LogOutAsync()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
    }
}
