using Shared.Models.DTO.ResponseDTO;
using Shared.Models.DTO.RequestDTO.Product;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Services;

public interface IProductService
{
    public Task<IEnumerable<ProductResponseDTO>> GetAllProductAsync();
    public Task<IEnumerable<ProductResponseDTO>> SearchProductByKeyAsync(string key);
    public Task<ProductResponseDTO> UpdateProductAsync(ProductUpdateDTO update);
    public Task<ProductResponseDTO> CreateProductAsync(ProductCreateDTO create, long offsets, int partitions);
    public Task<bool> HardDeleteProductAsync(ProductDeleteDTO delete);

    //public Task<ProductResponseDTO> ChangeGenderAsync(int id, Gender newStatus);
    public Task<ProductResponseDTO> FindProductByIdAsync(string id);
    public Task<string> CheckUniqueCodeAsync();
}
