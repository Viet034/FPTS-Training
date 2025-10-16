using Shared.Models.DTO.RequestDTO.Balance;
using Shared.Models.DTO.ResponseDTO;

namespace BalanceService.Services;

public interface IBalanceServices
{
    public Task<BalanceResponseDTO> CheckBalanceAsync(BalanceRequestDTO request);
}
