using PCStoreManagementSystem.ViewModels.SubPages;

namespace PCStoreManagementSystem.Views.SubPages;

public partial class EditProductView : ContentPage
{
	public EditProductView(EditProductViewModel editProductViewModel)
	{
		InitializeComponent();
		BindingContext = editProductViewModel;
	}
}
