using Oracle.ManagedDataAccess.Client;
using Shared.Models.DTO.RequestDTO.Notification;
using Shared.Models.DTO.ResponseDTO;

namespace NotificationService.Service;

public interface INotificationService
{
    public Task<NotificationResponseDTO> NotificationUser();
}
