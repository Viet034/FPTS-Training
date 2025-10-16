using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Ultility.EntityStatus;

namespace Shared.Models.DTO.ResponseDTO;

public class BalanceResponseDTO
{
    public string BuyerId { get; set; }
    public string OrderId { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
}
