using SQLite;

using PCStoreManagementSystem.Models.Database.Interfaces;
using PCStoreManagementSystem.Models.Database.Tables.Services;

namespace PCStoreManagementSystem.Models.Database.Tables;

/// <summary>
/// Product base class, used as a table in Database.
/// </summary>
[Serializable]
public class Product : IDatabaseKey
{
    private int _id;
    private string _name;
    private string _model;
    private Manufacturers _manufacturer;
    private Types _type;
    private decimal _price;
    private string _description;

    [PrimaryKey, AutoIncrement]
    public int Id { get => _id; set => _id = value; }

    public string Name { get => _name; set => _name = value; }
    public string Model { get => _model; set => _model = value; }
    public Manufacturers Manufacturer { get => _manufacturer; set => _manufacturer = value; }
    public Types Type { get => _type; set => _type = value; }
    public decimal Price { get => _price; set => _price = value; }
    public string Description { get => _description; set => _description = value; }
}
