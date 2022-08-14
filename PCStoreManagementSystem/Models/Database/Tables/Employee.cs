using SQLite;
using PCStoreManagementSystem.Models.Database.Interfaces;

namespace PCStoreManagementSystem.Models.Database.Tables;

/// <summary>
/// Employee base class, used as a table in Database.
/// </summary>
[Serializable]
public class Employee : IDatabaseKey, IEmployee
{
    private int _id;
    private string _username;
    private string _password;

    [PrimaryKey, AutoIncrement]
    public int Id { get => _id; set => _id = value; }
    public string Username { get => _username; set => _username = value; }
    public string Password { get => _password; set => _password = value; }
}
