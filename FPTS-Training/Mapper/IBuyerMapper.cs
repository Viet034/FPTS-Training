using Shared.Models;
using Shared.Models.DTO.RequestDTO.Buyer;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper;

public interface IBuyerMapper
{

    Buyers CreateToEntity(BuyerCreateDTO create);
    Buyers UpdateToEntity(BuyerUpdateDTO update);
    Buyers DeleteToEntity(BuyerDeleteDTO delete);

    BuyerResponseDTO EntityToResponse(Buyers entity);
    IEnumerable<BuyerResponseDTO> ListEntityToResponse(IEnumerable<Buyers> entities);
}
