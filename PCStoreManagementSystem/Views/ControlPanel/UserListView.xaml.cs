using PCStoreManagementSystem.ViewModels.ControlPanel;

namespace PCStoreManagementSystem.Views.ControlPanel;

public partial class UserListView : ContentPage
{
    private UserListViewModel _userListViewModel;

	public UserListView(UserListViewModel userListViewModel)
	{
		InitializeComponent();
        _userListViewModel = userListViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _userListViewModel = new();
        BindingContext = _userListViewModel;
        _userListViewModel.SelectedUser = null;

        base.OnNavigatedTo(args);
    }
}
