using PCStoreManagementSystem.ViewModels.SubPages;

namespace PCStoreManagementSystem.Views.SubPages;

public partial class EditOrderView : ContentPage
{
	public EditOrderView(EditOrderViewModel editOrderViewModel)
	{
		InitializeComponent();
		BindingContext = editOrderViewModel;
	}
}
