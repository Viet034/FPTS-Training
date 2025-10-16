using Shared.Models.DTO.RequestDTO.OrderItem;
using Shared.ProducerSetting;

namespace FPTS_Training.Services.OrderItemQueue;

public class OrderItemProducerMessage : IOrderItemMessage
{
    private readonly IProducerSettings _producer;

    public OrderItemProducerMessage(IProducerSettings producer)
    {
        _producer = producer;
    }

    public async Task<bool> CreateOrderItemProducerAsync(OrderItemCreateDTO create)
    {
        var topic = "OrderItemFPTCreated";
        var key = Guid.NewGuid().ToString();
        var result = await _producer.ProducerMessage<OrderItemCreateDTO>(topic, key, create);
        return true;
    }
}
