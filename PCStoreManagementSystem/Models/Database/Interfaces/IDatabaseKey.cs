namespace PCStoreManagementSystem.Models.Database.Interfaces;

/// <summary>
/// IDatabaseKey, implemented by every single base class witch is used as a table in the database.
/// </summary>
public interface IDatabaseKey
{
    int Id { get; set; }
}
