using static Shared.Ultility.EntityStatus;

namespace FPTS_Training.Models;

public class Products : BaseEntity
{
    public ProductStatus Status { get; set; }
    
}
