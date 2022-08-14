using PCStoreManagementSystem.ViewModels.ControlPanel;

namespace PCStoreManagementSystem.Views.ControlPanel;

public partial class OrderHistoryView : ContentPage
{
	private OrderHistoryViewModel _orderHistoryViewModel;

	public OrderHistoryView(OrderHistoryViewModel orderHistoryViewModel)
	{
		InitializeComponent();
		_orderHistoryViewModel = orderHistoryViewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		_orderHistoryViewModel = new();
		BindingContext = _orderHistoryViewModel;
		_orderHistoryViewModel.SelectedOrderHistory = null;

		base.OnNavigatedTo(args);
	}
}
