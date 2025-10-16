using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.RequestDTO.Product;
using Shared.ProducerSetting;

namespace FPTS_Training.Services.ProductQueue;

public class ProductProducerMessage : IProductMessage
{
    private readonly IProducerSettings _producer;

    public ProductProducerMessage(IProducerSettings producer)
    {
        _producer = producer;
    }

    public async Task<bool> CreateProductProducerAsync(ProductCreateDTO create)
    {
        //Produce message vào topic OrderCreated
        var topic = "ProductFPTCreated";
        var key = Guid.NewGuid().ToString();

        var result = await _producer.ProducerMessage<ProductCreateDTO>(topic, key, create);
        ///

        return true;
    }
}
