using FPTS_Training.Models.DTO.RequestDTO.Order;
using Shared.ProducerSetting;

namespace FPTS_Training.Services.OrderQueue;

public class OrderCreateConsumer : ConsumerGenericService<string, OrderCreateDTO>
{
    private readonly IServiceScopeFactory _service;

    public OrderCreateConsumer(IConfiguration config,IServiceScopeFactory service) 
        : base(config, "OrderFPTCreated", "OrderFPTCreatedId_V2")
    {
        _service = service;
    }

    protected override async Task HandleMessage(string key, OrderCreateDTO value, long offset, int partition)
    {
        var scope = _service.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IOrderService>();
        await service.CreateOrderAsync(value, offset, partition);
    }
}
