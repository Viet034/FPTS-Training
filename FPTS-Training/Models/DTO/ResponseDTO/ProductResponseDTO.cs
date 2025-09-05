using static Shared.Ultility.EntityStatus;

namespace FPTS_Training.Models.DTO.ResponseDTO;

public class ProductResponseDTO
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public ProductStatus Status { get; set; }       
}
