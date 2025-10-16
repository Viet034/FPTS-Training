using static Shared.Ultility.EntityStatus;

namespace Shared.Models.DTO.ResponseDTO;

public class OrderResponseDTO
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string BuyerId { get; set; }
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreateDate { get; set; }
}
