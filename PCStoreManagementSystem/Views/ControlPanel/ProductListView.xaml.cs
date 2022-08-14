using PCStoreManagementSystem.ViewModels.ControlPanel;

namespace PCStoreManagementSystem.Views.ControlPanel;

public partial class ProductListView : ContentPage
{
	private ProductListViewModel _productListViewModel;

	public ProductListView(ProductListViewModel productListViewModel)
	{
		InitializeComponent();
		_productListViewModel = productListViewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		_productListViewModel = new();
		BindingContext = _productListViewModel;
		_productListViewModel.SelectedProduct = null;

		base.OnNavigatedTo(args);
	}
}
