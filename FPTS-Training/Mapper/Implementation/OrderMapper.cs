using FPTS_Training.Models;
using FPTS_Training.Models.DTO.RequestDTO.Order;
using FPTS_Training.Models.DTO.ResponseDTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FPTS_Training.Mapper.Implementation;

public class OrderMapper : IOrderMapper
{
    public Orders CreateToEntity(OrderCreateDTO create)
    {
        Orders order = new Orders();
        order.Code = create.Code;
        order.Name = create.Name;
        order.BuyerId = create.BuyerId;
        order.Address = create.Address;
        order.Status = create.Status;
        order.CreateDate = DateTime.UtcNow.AddHours(7);
        order.CreateBy = create.Name;
        return order;
    }

    public Orders DeleteToEntity(OrderDeleteDTO delete)
    {
        Orders order = new Orders();
        order.Id = delete.Id;
        order.Code = delete.Code;
        order.Name = delete.Name;
        order.BuyerId = delete.BuyerId;
        order.Address = delete.Address;
        order.Status = delete.Status;
        return order;
    }

    public OrderResponseDTO EntityToResponse(Orders entity)
    {
        OrderResponseDTO response = new OrderResponseDTO();
        response.Id = entity.Id;
        response.Code = entity.Code;
        response.Name = entity.Name;
        response.BuyerId = entity.BuyerId;
        response.Address = entity.Address;
        response.Status = entity.Status;
        response.CreateDate = entity.CreateDate;
        return response;
    }

    public IEnumerable<OrderResponseDTO> ListEntityToResponse(IEnumerable<Orders> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public Orders UpdateToEntity(OrderUpdateDTO update)
    {
        Orders order = new Orders();
        order.Id = update.Id;
        order.Code = update.Code;
        order.Name = update.Name;
        order.BuyerId = update.BuyerId;
        order.Address = update.Address;
        order.Status = update.Status;
        return order;
    }
}
