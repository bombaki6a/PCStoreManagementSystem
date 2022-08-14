using PCStoreManagementSystem.ViewModels.ControlPanel;

namespace PCStoreManagementSystem.Views.ControlPanel;

public partial class OrdersView : ContentPage
{
	private OrdersViewModel _orderViewModel;

	public OrdersView(OrdersViewModel orderViewModel)
	{
		InitializeComponent();
		_orderViewModel = orderViewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		_orderViewModel = new(_orderViewModel.CurrentEmployee);
		BindingContext = _orderViewModel;
		_orderViewModel.SelectedOrder = null;
		
		base.OnNavigatedTo(args);
	}
}
