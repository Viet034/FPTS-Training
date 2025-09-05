using FPTS_Training.Models;
using FPTS_Training.Models.DTO.RequestDTO.OrderItem;
using FPTS_Training.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper;

public interface IOrderItemMapper
{
    OrderItems CreateToEntity(OrderItemCreateDTO create);
    OrderItems UpdateToEntity(OrderItemUpdateDTO update);
    OrderItems DeleteToEntity(OrderItemDeleteDTO delete);
    OrderItemResponseDTO EntityToResponse(OrderItems entity);
    IEnumerable<OrderItemResponseDTO> ListEntityToResponse(IEnumerable<OrderItems> entities);
}
