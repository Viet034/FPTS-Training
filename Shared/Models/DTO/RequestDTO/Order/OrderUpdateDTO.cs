using static Shared.Ultility.EntityStatus;

namespace Shared.Models.DTO.RequestDTO.Order;

public class OrderUpdateDTO
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
}
