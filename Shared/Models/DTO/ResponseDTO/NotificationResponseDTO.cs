using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Ultility.EntityStatus;

namespace Shared.Models.DTO.ResponseDTO;

public class NotificationResponseDTO
{

    public string OrderId { get; set; }
    public string Message { get; set; }
    public OrderStatus Status { get; set; }
}
