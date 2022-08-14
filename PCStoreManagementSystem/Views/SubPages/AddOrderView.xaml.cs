using PCStoreManagementSystem.ViewModels.SubPages;

namespace PCStoreManagementSystem.Views.SubPages;

public partial class AddOrderView : ContentPage
{
	public AddOrderView(AddOrderViewModel addOrderViewModel)
	{
		InitializeComponent();
		BindingContext = addOrderViewModel;
	}
}
