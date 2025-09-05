using static Shared.Ultility.EntityStatus;

namespace FPTS_Training.Models.DTO.RequestDTO.Product;

public class ProductUpdateDTO
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public ProductStatus Status { get; set; }
}
