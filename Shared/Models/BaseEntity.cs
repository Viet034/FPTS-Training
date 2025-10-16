namespace Shared.Models;

public abstract class BaseEntity
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }  
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string? UpdateBy { get; set; }
    public long Offsets { get; set; }
    public int Partitions { get; set; }
}
