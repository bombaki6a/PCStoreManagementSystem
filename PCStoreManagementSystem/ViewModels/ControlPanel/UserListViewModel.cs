using System.Collections.ObjectModel;

using PCStoreManagementSystem.Views.SubPages;

using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.ControlPanel;

/// <summary>
/// The UserListViewModel, binded to UserListView page
/// and implements the standart CRUD operations to the user list.
/// </summary>
public partial class UserListViewModel : ObservableObject
{
    [ObservableProperty]
    private User _selectedUser;
    [ObservableProperty]
    private ObservableCollection<User> _users;

    [ObservableProperty]
    private string _searchText;

    public UserListViewModel()
    {
        Users = new(Task.Run(async () => await DatabaseService<User>.GetTableAsync()).Result);
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        SelectedUser = null;

        if (SearchText != default)
        {
            List<User> users = await DatabaseService<User>.GetTableAsync();
            Users = new(users.Where(u => u.Email.Contains(SearchText) || u.FullName.Contains(SearchText)));
        }
        else
        {
            Users = new(await DatabaseService<User>.GetTableAsync());
        }
    }

    [RelayCommand]
    private async Task EditUserAsync()
    {
        if (SelectedUser != null)
        {
            Dictionary<string, object> args = new() { { $"{nameof(User)}", SelectedUser } };
            await Shell.Current.GoToAsync($"{nameof(EditUserView)}", args);
        }
        else
        {
            await Shell.Current.DisplayAlert("No user selected", "Please select and try again.", "Ok");
        }
    }

    [RelayCommand]
    private async Task RemoveUserAsync()
    {
        if (SelectedUser != null)
        {
            await DatabaseService<User>.RemoveColumnAsync(SelectedUser.Id);
            Users.Remove(SelectedUser);

            SelectedUser = null;
        }
        else
        {
            await Shell.Current.DisplayAlert("No user selected", "Please select and try again.", "Ok");
        }
    }

    [RelayCommand]
    private async Task AddUserAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddUserView));
    }
}
