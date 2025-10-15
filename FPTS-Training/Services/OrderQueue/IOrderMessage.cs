using FPTS_Training.Models.DTO.RequestDTO.Order;
using FPTS_Training.Models.DTO.RequestDTO.Product;

namespace FPTS_Training.Services.OrderQueue;

public interface IOrderMessage
{
    public Task<bool> CreateOrderProducerAsync(OrderCreateDTO create);
}
