namespace Shared.Models.DTO;

public class OrderDTO
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string BuyerId { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public long Offset { get; set; }
    public int Partition { get; set; }
}
