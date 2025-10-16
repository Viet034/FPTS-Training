using static Shared.Ultility.EntityStatus;

namespace Shared.Models;

public class Products : BaseEntity
{
    public ProductStatus Status { get; set; }
    
}
