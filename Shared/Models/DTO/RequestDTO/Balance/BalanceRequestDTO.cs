using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Ultility.EntityStatus;

namespace Shared.Models.DTO.RequestDTO.Balance;

public class BalanceRequestDTO
{
    public string BuyerId { get; set; }
    public decimal TotalPrice { get; set; }
    public string OrderId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
}

