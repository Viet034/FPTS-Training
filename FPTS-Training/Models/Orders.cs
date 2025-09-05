using static Shared.Ultility.EntityStatus;

namespace FPTS_Training.Models;

public class Orders : BaseEntity
{
    public string BuyerId { get; set; }
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
   
}
