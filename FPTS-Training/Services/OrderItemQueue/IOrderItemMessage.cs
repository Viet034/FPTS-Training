using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.RequestDTO.OrderItem;

namespace FPTS_Training.Services.OrderItemQueue;

public interface IOrderItemMessage
{
    public Task<bool> CreateOrderItemProducerAsync(OrderItemCreateDTO create);
}
