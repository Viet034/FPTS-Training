using Shared.Models.DTO.RequestDTO.Order;
using Shared.ConsumerSetting;

using Shared.ProducerSetting;

namespace FPTS_Training.Services.OrderQueue;

public class OrderCreateConsumer : ConsumerGenericService<string, OrderCreateDTO>
{
    private readonly IServiceScopeFactory _service;

    public OrderCreateConsumer(IConfiguration config,IServiceScopeFactory service) 
        : base(config, "BalanceFPTResult", "BalanceFPTResultGroup")
    {
        _service = service;
    }

    protected override async Task HandleMessage(string key, OrderCreateDTO value, long offset, int partition)
    {
        var scope = _service.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IOrderService>();
        var result = await service.CreateOrderAsync(value, offset, partition);

        var order = _service.CreateScope();
        var producer = order.ServiceProvider.GetRequiredService<IProducerSettings>();
        await producer.ProducerMessage("NotificationFPT", key, result);
    }
}
