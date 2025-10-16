using Shared.Models;
using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.ResponseDTO;
using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper;

public interface IOrderMapper
{
    Orders CreateToEntity(OrderCreateDTO create);
    Orders UpdateToEntity(OrderUpdateDTO update);
    Orders DeleteToEntity(OrderDeleteDTO delete);

    OrderResponseDTO EntityToResponse(Orders entity);
    IEnumerable<OrderResponseDTO> ListEntityToResponse(IEnumerable<Orders> entities);
}
