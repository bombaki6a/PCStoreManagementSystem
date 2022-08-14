using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;

namespace PCStoreManagementSystem.ViewModels;

/// <summary>
/// An abstract class that shortens repetitive commands
/// </summary>
public abstract class BaseViewModel : ObservableObject
{
    public ICommand BackCommand { get; private set; }

    public BaseViewModel()
    {
        BackCommand = new Command(async () => await BackAsync());
    }

    private static async Task BackAsync()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    protected static T GetItemIfExist<T>(IList<T> array)
    {
        if (array.Count > 0)
        {
            return array[0];
        }
        else
        {
            return default;
        }
    }
}
