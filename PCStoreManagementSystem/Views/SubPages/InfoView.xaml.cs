using PCStoreManagementSystem.ViewModels.SubPages;

namespace PCStoreManagementSystem.Views.SubPages;

public partial class InfoView : ContentPage
{
	public InfoView(InfoViewModel infoViewModel)
	{
		InitializeComponent();
		BindingContext = infoViewModel;
	}
}
