namespace FPTS_Training.Models.DTO;

public class OrderItemDTO
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Units { get; set; }
    public decimal UnitPrice { get; set; }
    public string ProductId { get; set; }
    public string OrderId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CreateBy { get; set; }
    public string UpdateBy { get; set; }
    public long Offset { get; set; }
    public int Partition { get; set; }
}
