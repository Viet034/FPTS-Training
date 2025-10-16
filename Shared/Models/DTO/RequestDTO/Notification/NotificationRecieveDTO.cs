using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Ultility.EntityStatus;

namespace Shared.Models.DTO.RequestDTO.Notification;

public class NotificationRecieveDTO
{

    public string OrderId { get; set; }
    public string Message { get; set; }
    public OrderStatus Status { get; set; }
}
