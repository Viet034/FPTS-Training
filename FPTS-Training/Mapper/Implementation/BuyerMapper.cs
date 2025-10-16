using Shared.Models;
using Shared.Models.DTO.RequestDTO.Buyer;
using Shared.Models.DTO.ResponseDTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FPTS_Training.Mapper.Implementation;

public class BuyerMapper : IBuyerMapper
{
    public Buyers CreateToEntity(BuyerCreateDTO create)
    {
        Buyers buyer = new Buyers();
        buyer.Code = create.Code;
        buyer.Name = create.Name;
        buyer.PaymentMethod  = create.PaymentMethod;
        buyer.CreateBy = create.Name;
        buyer.CreateDate = DateTime.UtcNow.AddHours(7);
        return buyer;
    }

    public Buyers DeleteToEntity(BuyerDeleteDTO delete)
    {
        Buyers buyer = new Buyers();
        buyer.Id = delete.Id;
        buyer.Code = delete.Code;
        buyer.Name = delete.Name;
        buyer.PaymentMethod = delete.PaymentMethod;
        return buyer;
    }

    public BuyerResponseDTO EntityToResponse(Buyers entity)
    {
        //BuyerResponseDTO response = new BuyerResponseDTO();
        //response.Id = entity.Id;
        //response.Code = entity.Id;
        //response.Name = entity.Id;
        //response.PaymentMethod = entity.Id;
        //response.CreateDate = entity.CreateDate;
        //return response;
        if (entity == null)
        {
            throw new Exception("Null");
        }

        return new BuyerResponseDTO
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            PaymentMethod = entity.PaymentMethod,
            CreateDate = entity.CreateDate
        };
    }

    public IEnumerable<BuyerResponseDTO> ListEntityToResponse(IEnumerable<Buyers> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public Buyers UpdateToEntity(BuyerUpdateDTO update)
    {
        Buyers buyer = new Buyers();
        buyer.Id = update.Id;
        
        buyer.Name = update.Name;
        buyer.PaymentMethod = update.PaymentMethod;
        buyer.UpdateDate = DateTime.UtcNow.AddHours(7);
        buyer.CreateBy = update.Name;
        return buyer;
    }
}
