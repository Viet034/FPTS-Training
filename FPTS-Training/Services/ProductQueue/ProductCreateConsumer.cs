using FPTS_Training.Models.DTO.RequestDTO.Product;
using Shared.ProducerSetting;
using System.Text.Json;

namespace FPTS_Training.Services.ProductQueue;

public class ProductCreateConsumer : ConsumerGenericService<string, ProductCreateDTO>
{
    private readonly IServiceScopeFactory _scope;



    public ProductCreateConsumer(IConfiguration config, IServiceScopeFactory scope)
        : base(config, "ProductFPTCreated", "ProductFPTCreatedId_V2")
    {
        _scope = scope;

    }
    protected override async Task HandleMessage(string key, ProductCreateDTO value, long offset, int partition)
    {
        try
        {
            Console.WriteLine($"[ProductCreateConsumer] Key={key}, Value={JsonSerializer.Serialize(value)}");
            var scope = _scope.CreateScope();
            //cách 1 tách logic
            var service = scope.ServiceProvider.GetRequiredService<IProductService>();
            await service.CreateProductAsync(value, offset, partition);
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi không xác định");
        }
        
    }
}
