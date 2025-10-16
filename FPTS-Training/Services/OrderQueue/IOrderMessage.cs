using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.RequestDTO.Product;
using Shared.Models.DTO.RequestDTO.Order;

namespace FPTS_Training.Services.OrderQueue;

public interface IOrderMessage
{
    public Task<bool> CreateOrderProducerAsync(OrderCreateDTO create);
}
