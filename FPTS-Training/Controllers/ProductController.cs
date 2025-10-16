using FPTS_Training.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Shared.Ultility.EntityStatus;
using System.Net;
using Shared.Models;
using Shared.Models.DTO.RequestDTO.Product;
using FPTS_Training.Services.ProductQueue;

namespace FPTS_Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly IProductMessage _message;

    public ProductController(IProductService service, IProductMessage message)
    {
        _service = service;
        _message = message;
    }

    [HttpPost("AddProduct")]
    [ProducesResponseType(typeof(IEnumerable<Products>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
   
    public async Task<IActionResult> AddProduct([FromBody] ProductCreateDTO create)
    {
        try
        {
            var response = await _message.CreateProductProducerAsync(create);
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
