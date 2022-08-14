namespace PCStoreManagementSystem.Models.Database.Interfaces;

/// <summary>
/// IEmployee, implemented by the CurrentEmployee base class, which holds information about the current employee.
/// </summary>
public interface IEmployee
{
    public int Id { get; set; }
    public string Username { get; set; }
}
