namespace Shared.Models;

public class OrderItems : BaseEntity
{
    
    public string Units { get; set; }
    public decimal UnitPrice { get; set; }
    public string ProductId { get; set; }
    public string OrderId { get; set; }
    

}
