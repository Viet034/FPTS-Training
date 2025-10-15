using FPTS_Training.Models.DTO.RequestDTO.Order;
using FPTS_Training.Models.DTO.RequestDTO.Product;

namespace FPTS_Training.Services.ProductQueue;

public interface IProductMessage
{
    public Task<bool> CreateProductProducerAsync(ProductCreateDTO create);
}
