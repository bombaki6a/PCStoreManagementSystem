namespace PCStoreManagementSystem.Models.Database.Interfaces;

/// <summary>
/// IOrder, implemented by the order base classes, which share tha same information for an order.
/// </summary>
public interface IOrder : IDatabaseKey
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
}
