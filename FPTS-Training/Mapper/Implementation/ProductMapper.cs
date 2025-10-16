using Shared.Models;
using Shared.Models.DTO.RequestDTO.Product;
using Shared.Models.DTO.ResponseDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.Models.DTO.ResponseDTO;

namespace FPTS_Training.Mapper.Implementation;

public class ProductMapper : IProductMapper
{
    public Products CreateToEntity(ProductCreateDTO create)
    {
        Products product = new Products();
        //product.Id = create.Id;
        product.Code = create.Code;
        product.Name = create.Name;
        product.Status = create.Status;
        product.CreateDate = DateTime.UtcNow.AddHours(7);
        product.CreateBy = create.Name;
        //product.UpdateDate = DateTime.UtcNow.AddHours(7);
        //product.UpdateBy = "base";
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
        //ProductResponseDTO response = new ProductResponseDTO();
        //if (entity == null)
        //    throw new Exception("Không tìm thấy sản phẩm sau khi insert");
        //response.Id = entity.Id;
        //response.Code = entity.Code;
        //response.Name = entity.Name;
        //response.Status = entity.Status;

        //return response;
        //if(entity == null)
        //{
        //    throw new Exception("Null");
        //}
        return new ProductResponseDTO
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            Status = entity.Status
        };

    }

    public IEnumerable<ProductResponseDTO> ListEntityToResponse(IEnumerable<Products> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList(); 
    }

    public Products UpdateToEntity(ProductUpdateDTO update)
    {
        Products product = new Products();
        //product.Id = update.Id;
        product.Code = update.Code;
        product.Name = update.Name;
        product.Status = update.Status;
        product.UpdateDate = DateTime.UtcNow.AddHours(7);
        product.UpdateBy = update.Name;
        return product;
    }
}
