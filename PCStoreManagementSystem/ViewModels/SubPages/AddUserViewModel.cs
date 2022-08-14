using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels.SubPages;

/// <summary>
/// The AddUserViewModel, binded to AddUserView page, allows users to be added.
/// </summary>
public partial class AddUserViewModel : BaseViewModel
{
    [ObservableProperty]
    private User _user = new();

    private static bool IsAnyNullOrEmpty(object user)
    {
        return user.GetType()
            .GetProperties()
            .Where(pt => pt.PropertyType == typeof(string))
            .Select(v => (string)v.GetValue(user))
            .Any(value => string.IsNullOrWhiteSpace(value));
    }

    private bool IsUserExist()
    {
        List<User> users = Task.Run(async () => await DatabaseService<User>.GetTableAsync()).Result;
        return users.Where(u => u.Email == User.Email).ToList().Count != 0;
    }

    [RelayCommand]
    private async Task AddAsync()
    {
        if (IsAnyNullOrEmpty(User))
        {
            User = new();
            await Shell.Current.DisplayAlert("There is an empty field", "Please fill it out and try again.", "Ok");
        }
        else if (IsUserExist())
        {
            User = new();
            await Shell.Current.DisplayAlert("This e-mail is already in use", "Please try another one.", "Ok");
        }
        else
        {
            await DatabaseService<User>.AddColumnAsync(User);
            await Shell.Current.DisplayAlert("User added successfully", "Press Ok and return to the user list", "Ok");

            BackCommand.Execute(null);
        }
    }
}
