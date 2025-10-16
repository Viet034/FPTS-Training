using Shared.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models.DTO.RequestDTO.Balance;
using Shared.Models.DTO.ResponseDTO;

namespace BalanceService.Services;

public class BalanceServices : IBalanceServices
{
    
    private static Dictionary<string, decimal> _balances = new()
    {
        { "11", 500000 },
        { "B002", 300000 },
        { "B003", 1000000 }
    };

    

    public async Task<BalanceResponseDTO> CheckBalanceAsync(BalanceRequestDTO request)
    {
        
        await Task.Delay(100); 

        if (!_balances.ContainsKey(request.BuyerId))
            return new BalanceResponseDTO { BuyerId = request.BuyerId, IsSuccess = false, Message = "Không tìm thấy tài khoản", Address = request.Address, Name = request.Name, Code = request.Code, Status = request.Status };

        var currentBalance = _balances[request.BuyerId];
        if (currentBalance >= request.TotalPrice)
        {
            _balances[request.BuyerId] -= request.TotalPrice;
            return new BalanceResponseDTO { BuyerId = request.BuyerId, IsSuccess = true, Message = "Đủ số dư", Address = request.Address, Name = request.Name, Code = request.Code, Status = request.Status };
        }
        else
        {
            return new BalanceResponseDTO { BuyerId = request.BuyerId, IsSuccess = false, Message = "Không đủ số dư", Address = request.Address, Name = request.Name, Code = request.Code, Status = request.Status };
        }
    }
}
