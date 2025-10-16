using Shared.Models.DTO.RequestDTO.Buyer;
using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.ResponseDTO;
using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.ResponseDTO;
using Shared.Ultility;

namespace FPTS_Training.Services;

public interface IOrderService
{
    public Task<IEnumerable<OrderResponseDTO>> GetAllOrderAsync();
    public Task<IEnumerable<OrderResponseDTO>> SearchOrderByKeyAsync(string key);
    public Task<OrderResponseDTO> UpdateOrderAsync(OrderUpdateDTO update);
    public Task<OrderResponseDTO> CreateOrderAsync(OrderCreateDTO create, long offsets, int partitions);
    public Task<bool> HardDeleteOrderAsync(OrderDeleteDTO delete);

    //public Task<ProductResponseDTO> ChangeGenderAsync(int id, Gender newStatus);
    public Task<OrderResponseDTO> FindOrderByIdAsync(int id);
    public Task<string> CheckUniqueCodeAsync();
}
