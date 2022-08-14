using SQLite;

using PCStoreManagementSystem.Models.Database.Services;
using PCStoreManagementSystem.Models.Database.Interfaces;

namespace PCStoreManagementSystem.Models.Database.Tables;

/// <summary>
/// OrderHistory base class, used as a table in Database.
/// </summary>
[Serializable]
public class OrderHistory : IOrder
{
    private int _id;

    private int _userId;
    private int _productId;
    private int _quantity;
    private DateTime _date;

    private int _currentEmployeeId;
    private bool _accept;

    [PrimaryKey]
    public int Id { get => _id; set => _id = value; }

    public int UserId { get => _userId; set => _userId = value; }
    public int ProductId { get => _productId; set => _productId = value; }
    public int Quantity { get => _quantity; set => _quantity = value; }
    public DateTime Date { get => _date; set => _date = value; }

    public int CurrentEmployeeId { get => _currentEmployeeId; set => _currentEmployeeId = value; }
    public bool Accept { get => _accept; set => _accept = value; }

    // Relationship  properties
    public Employee CurrentEmployee
    {
        get
        {
            List<Employee> employees = Task.Run(async () => await DatabaseService<Employee>.GetTableAsync()).Result;
            return employees.Where(e => e.Id == CurrentEmployeeId).ToList()[0];
        }
    }

    public User User
    {
        get
        {
            List<User> users = Task.Run(async () => await DatabaseService<User>.GetTableAsync()).Result;
            return users.Where(u => u.Id == UserId).ToList()[0];
        }
    }

    public Product Product
    {
        get
        {
            List<Product> products = Task.Run(async () => await DatabaseService<Product>.GetTableAsync()).Result;
            return products.Where(p => p.Id == ProductId).ToList()[0];
        }
    }
}
