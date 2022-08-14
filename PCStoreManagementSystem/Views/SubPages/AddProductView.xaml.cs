using PCStoreManagementSystem.ViewModels.SubPages;

namespace PCStoreManagementSystem.Views.SubPages;

public partial class AddProductView : ContentPage
{
	public AddProductView(AddProductViewModel addProductViewModel)
	{
		InitializeComponent();
		BindingContext = addProductViewModel;
	}
}
