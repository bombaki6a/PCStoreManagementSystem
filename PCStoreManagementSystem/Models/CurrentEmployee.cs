using PCStoreManagementSystem.Models.Database.Interfaces;

namespace PCStoreManagementSystem.Models;

/// <summary>
/// The class serves to establish and store information
/// about the current employee using the application.
/// </summary>
public class CurrentEmployee : IEmployee
{
    public int Id { get; set; }
    public string Username { get; set; }
}
