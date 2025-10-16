namespace Shared.Models.DTO.ResponseDTO;

public class BuyerResponseDTO
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string PaymentMethod { get; set; }
   
    public DateTime CreateDate { get; set; }
}
