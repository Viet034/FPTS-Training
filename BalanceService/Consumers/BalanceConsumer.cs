using BalanceService.Services;
using Shared.Models.DTO.RequestDTO.Order;
using Shared.ConsumerSetting;
using Shared.Models.DTO.RequestDTO.Balance;
using Shared.ProducerSetting;
using System.Text.Json;

namespace BalanceService.Consumers;

public class BalanceConsumer : ConsumerGenericService<string, BalanceRequestDTO>
{
    private readonly IServiceScopeFactory _scope;
    

    public BalanceConsumer(IConfiguration config, IServiceScopeFactory scope)
        : base(config, "BalanceFPTValidation", "BalanceFPTValidationGroupV1")
    {
        _scope = scope;
        
    }

    protected override async Task HandleMessage(string key, BalanceRequestDTO value, long offset, int partition)
    {
        

        var scope = _scope.CreateScope();
        var balanceService = scope.ServiceProvider.GetRequiredService<IBalanceServices>();

        var result = await balanceService.CheckBalanceAsync(value);

        var service = _scope.CreateScope();
        var producer = service.ServiceProvider.GetRequiredService<IProducerSettings>();
        Console.WriteLine($"result: {value.Address}, {value.Code}, {value.Name}, {value.Status}");
        await producer.ProducerMessage("BalanceFPTResult", key, result);
        
    }

    
}
