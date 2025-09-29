namespace FPTS_Training.Models.DTO.RequestDTO.OrderItem;

public class OrderItemUpdateDTO
{
    public string Id { get; set; }
   
    public string Name { get; set; }
    public string Units { get; set; }
    public decimal UnitPrice { get; set; }
    public string ProductId { get; set; }

}
