using FPTS_Training.Models;
using FPTS_Training.Models.DTO.RequestDTO.Product;
using FPTS_Training.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper;

public interface IProductMapper
{
    Products CreateToEntity(ProductCreateDTO create);
    Products UpdateToEntity(ProductUpdateDTO update);
    Products DeleteToEntity(ProductDeleteDTO delete);
    ProductResponseDTO EntityToResponse(Products entity);
    IEnumerable<ProductResponseDTO> ListEntityToResponse(IEnumerable<Products> entities);
}
