using Shared.Models.DTO.RequestDTO.Product;
using Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FPTS_Training.Services;
using Shared.Models.DTO.RequestDTO.Buyer;
using Shared.Models.DTO.RequestDTO.OrderItem;

namespace FPTS_Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuyersController : ControllerBase
{
    private readonly IBuyerService _service;

    public BuyersController(IBuyerService service)
    {
        _service = service;
    }

    [HttpPost("AddBuyers")]
    [ProducesResponseType(typeof(IEnumerable<Buyers>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> AddBuyers([FromBody] BuyerCreateDTO create, long offsets, int partitions)
    {
        try
        {
            var response = await _service.CreateBuyerAsync(create, offsets, partitions);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }


    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(IEnumerable<Buyers>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<ActionResult<IEnumerable<Buyers>>> GetAllBuyer()
    {
        try
        {
            var response = await _service.GetAllBuyerAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPut("Update")]
    [ProducesResponseType(typeof(IEnumerable<Buyers>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> UpdateProduct([FromBody] BuyerUpdateDTO update)
    {
        try
        {
            var response = await _service.UpdateBuyerAsync(update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpDelete("DeletePermanent")]
    [ProducesResponseType(typeof(IEnumerable<Buyers>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> HardDeleteProduct(BuyerDeleteDTO delete)
    {
        try
        {
            var response = await _service.HardDeleteBuyerAsync(delete);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}
