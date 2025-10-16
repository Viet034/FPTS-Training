using Shared.Models.DTO.ResponseDTO;
using Shared.Models;
using Shared.Models.DTO.RequestDTO.OrderItem;
using Shared.Models.DTO.ResponseDTO;
using Shared.Models.DTO.ResponseDTO;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper;

public interface IOrderItemMapper
{
    OrderItems CreateToEntity(OrderItemCreateDTO create);
    OrderItems UpdateToEntity(OrderItemUpdateDTO update);
    OrderItems DeleteToEntity(OrderItemDeleteDTO delete);
    OrderItemResponseDTO EntityToResponse(OrderItems entity);
    IEnumerable<OrderItemResponseDTO> ListEntityToResponse(IEnumerable<OrderItems> entities);
}
