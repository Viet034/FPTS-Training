using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.RequestDTO.Product;

namespace FPTS_Training.Services.ProductQueue;

public interface IProductMessage
{
    public Task<bool> CreateProductProducerAsync(ProductCreateDTO create);
}
