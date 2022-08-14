using PCStoreManagementSystem.ViewModels.SubPages;

namespace PCStoreManagementSystem.Views.SubPages;

public partial class AddUserView : ContentPage
{
	public AddUserView(AddUserViewModel addUserViewModel)
	{
		InitializeComponent();
		BindingContext = addUserViewModel;
	}
}
