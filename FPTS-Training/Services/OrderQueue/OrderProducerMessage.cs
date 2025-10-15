using FPTS_Training.Models.DTO.RequestDTO.Order;
using Shared.ProducerSetting;

namespace FPTS_Training.Services.OrderQueue;

public class OrderProducerMessage : IOrderMessage
{
    private readonly IProducerSettings _producer;

    public OrderProducerMessage(IProducerSettings producer)
    {
        _producer = producer;
    }

    public async Task<bool> CreateOrderProducerAsync(OrderCreateDTO create)
    {
        var topic = "OrderFPTCreated";
        var key = Guid.NewGuid().ToString();
        var result = await _producer.ProducerMessage<OrderCreateDTO>(topic, key, create);
        return true;
    }
}
