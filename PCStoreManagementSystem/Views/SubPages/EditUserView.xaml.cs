using PCStoreManagementSystem.ViewModels.SubPages;

namespace PCStoreManagementSystem.Views.SubPages;

public partial class EditUserView : ContentPage
{
	public EditUserView(EditUserViewModel editUserViewModel)
	{
		InitializeComponent();
		BindingContext = editUserViewModel;
	}
}
