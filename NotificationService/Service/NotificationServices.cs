using Shared.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Models.DTO.RequestDTO.Notification;
using Shared.Models.DTO.ResponseDTO;
using static Shared.Ultility.EntityStatus;

namespace NotificationService.Service;

public class NotificationServices : INotificationService
{
    private readonly FPTSTrainingDBContext _context;

    public NotificationServices(FPTSTrainingDBContext context)
    {
        _context = context;
    }

    public async Task<NotificationResponseDTO> NotificationUser()
    {
        var co = await _context.Orders.OrderByDescending(c => c.CreateDate).Where(a => a.Status == OrderStatus.created).FirstOrDefaultAsync();
        if(co == null)
        {
            throw new Exception("Không có đơn nào");
        }
        
        return new NotificationResponseDTO 
        { 
            OrderId = co.Id.ToString(),
            Status = co.Status,
            Message = "Đơn hàng của bạn đã được tạo" 
        };
    }
}
