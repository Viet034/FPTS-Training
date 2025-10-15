using FPTS_Training.Models.DTO.RequestDTO.OrderItem;
using Shared.ProducerSetting;

namespace FPTS_Training.Services.OrderItemQueue;

public class OrderItemCreateConsumer : ConsumerGenericService<string, OrderItemCreateDTO>
{
    private readonly IServiceScopeFactory _scope;

    public OrderItemCreateConsumer(IConfiguration config,IServiceScopeFactory scope)
        : base(config, "OrderItemFPTCreated", "OrderItemFPTCreatedId")
    {
        _scope = scope;
    }

    protected override Task HandleMessage(string key, OrderItemCreateDTO value, long offset, int partition)
    {
        var scope = _scope.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IOrderItemService>();
        var result = service.CreateOrderItemAsync(value, offset, partition);
        return result;
    }
}
