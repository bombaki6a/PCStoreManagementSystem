using PCStoreManagementSystem.Views;
using PCStoreManagementSystem.Views.SubPages;
using PCStoreManagementSystem.Views.ControlPanel;

using PCStoreManagementSystem.ViewModels;
using PCStoreManagementSystem.ViewModels.SubPages;
using PCStoreManagementSystem.ViewModels.ControlPanel;

using PCStoreManagementSystem.Models;
using PCStoreManagementSystem.Models.Database.Interfaces;

namespace PCStoreManagementSystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Hack Regular Nerd Font Complete Windows Compatible.ttf", "Hack");
			});

		// CurrentEmployee
		builder.Services.AddSingleton<IEmployee, CurrentEmployee>();

		// AppShell
		builder.Services.AddTransient<AppShellViewModel>();

		// Login Page
		builder.Services.AddTransient<LoginView>();
		builder.Services.AddTransient<LoginViewModel>();

		// Orders Page
		builder.Services.AddTransient<OrdersView>();
		builder.Services.AddTransient<OrdersViewModel>();
		builder.Services.AddTransient<AddOrderView>();
		builder.Services.AddTransient<AddOrderViewModel>();
		builder.Services.AddTransient<EditOrderView>();
		builder.Services.AddTransient<EditOrderViewModel>();

		// Order History Page
		builder.Services.AddTransient<OrderHistoryView>();
		builder.Services.AddTransient<OrderHistoryViewModel>();

		// Info Page
		builder.Services.AddTransient<InfoView>();
		builder.Services.AddTransient<InfoViewModel>();

		// Product List Page
		builder.Services.AddTransient<ProductListView>();
		builder.Services.AddTransient<ProductListViewModel>();
		builder.Services.AddTransient<AddProductView>();
		builder.Services.AddTransient<AddProductViewModel>();
		builder.Services.AddTransient<EditProductView>();
		builder.Services.AddTransient<EditProductViewModel>();

		// User List Page
		builder.Services.AddTransient<UserListView>();
		builder.Services.AddTransient<UserListViewModel>();
		builder.Services.AddTransient<AddUserView>();
		builder.Services.AddTransient<AddUserViewModel>();
		builder.Services.AddTransient<EditUserView>();
		builder.Services.AddTransient<EditUserViewModel>();

		return builder.Build();
	}
}
