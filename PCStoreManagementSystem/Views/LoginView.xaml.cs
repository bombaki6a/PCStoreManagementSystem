using PCStoreManagementSystem.ViewModels;

namespace PCStoreManagementSystem.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
    }
}
