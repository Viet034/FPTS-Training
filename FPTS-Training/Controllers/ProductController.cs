using FPTS_Training.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Shared.Ultility.EntityStatus;
using System.Net;
using FPTS_Training.Models;
using FPTS_Training.Models.DTO.RequestDTO.Product;

namespace FPTS_Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost("AddProduct")]
    [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
   
    public async Task<IActionResult> AddProduct([FromBody] ProductCreateDTO create,long offsets, int partitions)
    {
        try
        {
            var response = await _service.CreateProductAsync(create,offsets,partitions);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }


    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    
    public async Task<ActionResult<IEnumerable<Products>>> GetAllProduct()
    {
        try
        {
            var response = await _service.GetAllProductAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    

    [HttpGet("findId/{id}")]
    [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    
    
    public async Task<IActionResult> FindById(string id)
    {
        try
        {
            var response = await _service.FindProductByIdAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    


    [HttpPut("Update")]
    [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    
    public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO update)
    {
        try
        {
            var response = await _service.UpdateProductAsync(update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }




    //[HttpPut("ChangeSstatus/{id}")]
    //[ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
    //[ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    //[Authorize(Roles = "Admin,Employee")]
    //public async Task<IActionResult> SoftDeleteProduct(int id, ProductStatus newStatus)
    //{
    //    try
    //    {
    //        var response = await _service.SoftDeleteProductAsync(id, newStatus);
    //        return Ok(response);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.ToString());
    //    }
    //}



    [HttpDelete("DeletePermanent")]
    [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    
    public async Task<IActionResult> HardDeleteProduct(ProductDeleteDTO delete)
    {
        try
        {
            var response = await _service.HardDeleteProductAsync(delete);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}
