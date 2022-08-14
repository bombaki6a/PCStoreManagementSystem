using PCStoreManagementSystem.Views.ControlPanel;

using PCStoreManagementSystem.Models.Database.Tables;
using PCStoreManagementSystem.Models.Database.Services;
using PCStoreManagementSystem.Models.Database.Interfaces;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels;

/// <summary>
/// The LoginViewModel, validates login information and sets the current logged in employee.
/// </summary>
public partial class LoginViewModel : ObservableObject
{
    public IEmployee _currentEmployee;

    [ObservableProperty]
    private string _username;
    [ObservableProperty]
    private string _password;

    public LoginViewModel(IEmployee currentEmployee)
    {
        _currentEmployee = currentEmployee;
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        List<Employee> accounts = await DatabaseService<Employee>.GetTableAsync();
        accounts = accounts.Where(a => (a.Username == Username) && (a.Password == Password)).ToList();

        Username = default;
        Password = default;

        if (accounts.Count > 0)
        {
            _currentEmployee.Id = accounts[0].Id;
            _currentEmployee.Username = accounts[0].Username;

            await Shell.Current.GoToAsync($"//{nameof(OrdersView)}");
        }
        else
        {
            await Shell.Current.DisplayAlert("Invalid Username or Password.", "Please try again.", "Ok");
        }
    }
}
