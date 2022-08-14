using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.SubPages;

/// <summary>
/// The EditUserViewModel, binded to EditUserView page, allows editing of a user.
/// </summary>
[QueryProperty(nameof(User), nameof(User))]
public partial class EditUserViewModel : BaseViewModel
{
    [ObservableProperty]
    private User _user;

    [RelayCommand]
    private async Task EditAsync()
    {
        await DatabaseService<User>.UpdateColumnAsync(User);
        await Shell.Current.DisplayAlert("Edit success", "Press Ok and return to the user list", "Ok");

        BackCommand.Execute(null);
    }
}
