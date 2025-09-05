using static Shared.Ultility.EntityStatus;

namespace FPTS_Training.Models.DTO.RequestDTO.Order;

public class OrderDeleteDTO
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string BuyerId { get; set; }
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
}
