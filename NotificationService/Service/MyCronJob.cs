using Quartz;

namespace NotificationService.Service;

public class MyCronJob : IJob
{
    private readonly INotificationService _service;

    public MyCronJob(INotificationService service)
    {
        _service = service;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var cron = await _service.NotificationUser();
    }
}
