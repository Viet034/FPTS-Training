using Shared.Models.DTO.RequestDTO.Buyer;
using Shared.Models.DTO.RequestDTO.Product;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Services;

public interface IBuyerService
{
    public Task<IEnumerable<BuyerResponseDTO>> GetAllBuyerAsync();
    public Task<IEnumerable<BuyerResponseDTO>> SearchBuyerByKeyAsync(string key);
    public  Task<BuyerResponseDTO> UpdateBuyerAsync( BuyerUpdateDTO update);
    public Task<BuyerResponseDTO> CreateBuyerAsync(BuyerCreateDTO create, long offsets, int partitions);
    public  Task<bool> HardDeleteBuyerAsync(BuyerDeleteDTO delete);

    //public Task<ProductResponseDTO> ChangeGenderAsync(int id, Gender newStatus);
    public Task<BuyerResponseDTO> FindBuyerByIdAsync(int id);
    public Task<string> CheckUniqueCodeAsync();
}
