using PCStoreManagementSystem.ViewModels;
using PCStoreManagementSystem.Views.SubPages;
using PCStoreManagementSystem.Views.ControlPanel;

namespace PCStoreManagementSystem;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = new AppShellViewModel();
    }
}
