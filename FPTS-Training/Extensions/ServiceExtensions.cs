using FPTS_Training.Mapper.Implementation;
using FPTS_Training.Mapper;
using FPTS_Training.Services.Implement;
using FPTS_Training.Services.OrderQueue;
using FPTS_Training.Services.ProductQueue;
using FPTS_Training.Services;
using Shared.ProducerSetting;
using FPTS_Training.Services.OrderItemQueue;

namespace FPTS_Training.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ServiceExtend(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductMapper, ProductMapper>();
        services.AddScoped<IBuyerService, BuyerService>();
        services.AddScoped<IBuyerMapper, BuyerMapper>();
        services.AddScoped<IOrderService, OrderSerrvice>();
        services.AddScoped<IOrderMapper, OrderMapper>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IOrderItemMapper, OrderItemMapper>();
        services.AddScoped<IProducerSettings, ProducerSettings>();
        services.AddScoped<IProductMessage, ProductProducerMessage>();
        services.AddHostedService<ProductCreateConsumer>();
        services.AddScoped<IOrderMessage, OrderProducerMessage>();
        services.AddHostedService<OrderCreateConsumer>();
        services.AddScoped<IOrderItemMessage, OrderItemProducerMessage>();
        services.AddHostedService<OrderItemCreateConsumer>();
        return services;
    }
    
}
