using static Shared.Ultility.EntityStatus;

namespace Shared.Models.DTO.RequestDTO.Order;

public class OrderCreateDTO
{
    
    public string Code { get; set; }
    public string Name { get; set; }
    public string BuyerId { get; set; }
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
}
