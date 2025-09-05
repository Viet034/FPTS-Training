using FPTS_Training.Models;
using FPTS_Training.Models.DTO.RequestDTO.Order;
using FPTS_Training.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper;

public interface IOrderMapper
{
    Orders CreateToEntity(OrderCreateDTO create);
    Orders UpdateToEntity(OrderUpdateDTO update);
    Orders DeleteToEntity(OrderDeleteDTO delete);

    OrderResponseDTO EntityToResponse(Orders entity);
    IEnumerable<OrderResponseDTO> ListEntityToResponse(IEnumerable<Orders> entities);
}
