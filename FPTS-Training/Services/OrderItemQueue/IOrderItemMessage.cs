using FPTS_Training.Models.DTO.RequestDTO.Order;
using FPTS_Training.Models.DTO.RequestDTO.OrderItem;

namespace FPTS_Training.Services.OrderItemQueue;

public interface IOrderItemMessage
{
    public Task<bool> CreateOrderItemProducerAsync(OrderItemCreateDTO create);
}
