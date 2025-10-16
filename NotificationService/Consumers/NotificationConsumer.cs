using NotificationService.Service;
using Shared.ConsumerSetting;
using Shared.Models.DTO.RequestDTO.Notification;

namespace NotificationService.Consumers;

public class NotificationConsumer : ConsumerGenericService<string, NotificationRecieveDTO>
{
    private readonly IServiceScopeFactory _scope;

    public NotificationConsumer(IConfiguration config,IServiceScopeFactory scope)
        :base(config, "NotificationFPT", "NotificationFPTGroup")
    {
        _scope = scope;
    }

    protected override async Task HandleMessage(string key, NotificationRecieveDTO value, long offset, int partition)
    {
        var scope = _scope.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<INotificationService>();
        await service.NotificationUser();
        
            
    }
}
