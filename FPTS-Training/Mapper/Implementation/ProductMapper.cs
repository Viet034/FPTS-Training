using FPTS_Training.Models;
using FPTS_Training.Models.DTO.RequestDTO.Product;
using FPTS_Training.Models.DTO.ResponseDTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FPTS_Training.Mapper.Implementation;

public class ProductMapper : IProductMapper
{
    public Products CreateToEntity(ProductCreateDTO create)
    {
        Products product = new Products();
        product.Code = create.Code;
        product.Name = create.Name;
        product.Status = create.Status;
        product.CreateDate = DateTime.UtcNow.AddHours(7);
        product.CreateBy = create.Name;
        return product;
    }

    public Products DeleteToEntity(ProductDeleteDTO delete)
    {
        Products product = new Products();
        product.Id = delete.Id;
        product.Code = delete.Code;
        product.Name = delete.Name;
        product.Status = delete.Status;
        product.CreateDate = DateTime.UtcNow.AddHours(7);
        product.CreateBy = delete.Name;
        return product;
    }

    public ProductResponseDTO EntityToResponse(Products entity)
    {
        ProductResponseDTO response = new ProductResponseDTO();
        response.Id = entity.Id;
        response.Code = entity.Code;
        response.Name = entity.Name;
        response.Status = entity.Status;
        return response;

    }

    public IEnumerable<ProductResponseDTO> ListEntityToResponse(IEnumerable<Products> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList(); 
    }

    public Products UpdateToEntity(ProductUpdateDTO update)
    {
        Products product = new Products();
        product.Id = update.Id;
        product.Code = update.Code;
        product.Name = update.Name;
        product.Status = update.Status;
        product.UpdateDate = DateTime.UtcNow.AddHours(7);
        product.UpdateBy = update.Name;
        return product;
    }
}
