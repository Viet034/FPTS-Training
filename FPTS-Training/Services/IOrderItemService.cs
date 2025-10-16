using Shared.Models.DTO.ResponseDTO;
using Shared.Models.DTO.RequestDTO.OrderItem;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Services;

public interface IOrderItemService
{
    public Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderItemAsync();
    public Task<IEnumerable<OrderItemResponseDTO>> SearchOrderItemByKeyAsync(string key);
    public Task<OrderItemResponseDTO> UpdateOrderItemAsync(OrderItemUpdateDTO update);
    public Task<OrderItemResponseDTO> CreateOrderItemAsync(OrderItemCreateDTO create, long offsets, int partitions);
    public  Task<bool> HardDeleteOrderItemAsync(OrderItemDeleteDTO delete);

    //public Task<ProductResponseDTO> ChangeGenderAsync(int id, Gender newStatus);
    public Task<IEnumerable<OrderItemResponseDTO>> FindOrderItemByIdAsync(string id);
    public Task<string> CheckUniqueCodeAsync();
}
