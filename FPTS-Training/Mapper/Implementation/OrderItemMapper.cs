using Shared.Models;
using Shared.Models.DTO.RequestDTO.OrderItem;
using Shared.Models.DTO.ResponseDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper.Implementation;

public class OrderItemMapper : IOrderItemMapper
{
    public OrderItems CreateToEntity(OrderItemCreateDTO create)
    {
        OrderItems item = new OrderItems();
        item.Code = create.Code;
        item.Name = create.Name;
        item.Units = create.Units;
        item.UnitPrice = create.UnitPrice;
        item.ProductId = create.ProductId;
        item.OrderId = create.OrderId;
        item.CreateDate = DateTime.UtcNow.AddHours(7);
        item.CreateBy = create.Name;
        return item;
    }

    public OrderItems DeleteToEntity(OrderItemDeleteDTO delete)
    {
        OrderItems item = new OrderItems();
        item.Id = delete.Id;
        item.Code = delete.Code;
        item.Name = delete.Name;
        item.Units = delete.Units;
        item.UnitPrice = delete.UnitPrice;
        item.ProductId = delete.ProductId;
        item.OrderId = delete.OrderId;
        item.CreateDate = DateTime.UtcNow.AddHours(7);
        item.CreateBy = delete.Name;
        return item;
    }

    public OrderItemResponseDTO EntityToResponse(OrderItems entity)
    {
        OrderItemResponseDTO response = new OrderItemResponseDTO();
        response.Id = entity.Id;
        response.Code = entity.Code;
        response.Name = entity.Name;
        response.Units = entity.Units;
        response.UnitPrice = entity.UnitPrice;
        response.ProductId = entity.ProductId;
        response.OrderId = entity.OrderId;
        response.CreateDate = entity.CreateDate;
        return response;
    }

    public IEnumerable<OrderItemResponseDTO> ListEntityToResponse(IEnumerable<OrderItems> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public OrderItems UpdateToEntity(OrderItemUpdateDTO update)
    {
        OrderItems item = new OrderItems();
        item.Id = update.Id;
        
        item.Name = update.Name;
        item.Units = update.Units;
        item.UnitPrice = update.UnitPrice;
        item.ProductId = update.ProductId;
        
        item.UpdateDate = DateTime.UtcNow.AddHours(7);
        item.UpdateBy = update.Name;
        return item;
    }
}
