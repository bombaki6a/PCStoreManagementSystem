using SQLite;
using PCStoreManagementSystem.Models.Database.Interfaces;

namespace PCStoreManagementSystem.Models.Database.Tables;

/// <summary>
/// User base class, used as a table in Database.
/// </summary>
[Serializable]
public class User : IDatabaseKey
{
    private int _id;
    private string _email;
    private string _password;
    private string _fullName;
    private string _phoneNumber;
    private string _address;

    [PrimaryKey, AutoIncrement]
    public int Id { get => _id; set => _id = value; }

    public string Email { get => _email; set => _email = value; }
    public string Password { get => _password; set => _password = value; }
    public string FullName { get => _fullName; set => _fullName = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    public string Address { get => _address; set => _address = value; }
}
