namespace Shared.Models.DTO.RequestDTO.OrderItem;

public class OrderItemCreateDTO
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Units { get; set; }
    public decimal UnitPrice { get; set; }
    public string ProductId { get; set; }
    public string OrderId { get; set; }
}
