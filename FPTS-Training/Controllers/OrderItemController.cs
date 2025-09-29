using FPTS_Training.Models.DTO.RequestDTO.Order;
using FPTS_Training.Models;
using FPTS_Training.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FPTS_Training.Models.DTO.RequestDTO.OrderItem;

namespace FPTS_Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _service;

    public OrderItemController(IOrderItemService service)
    {
        _service = service;
    }

    [HttpPost("AddOrderItem")]
    [ProducesResponseType(typeof(IEnumerable<OrderItems>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> AddBuyers([FromBody] OrderItemCreateDTO create, long offsets, int partitions)
    {
        try
        {
            var response = await _service.CreateOrderItemAsync(create, offsets, partitions);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }


    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(IEnumerable<OrderItems>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<ActionResult<IEnumerable<OrderItems>>> GetAllOrderItems()
    {
        try
        {
            var response = await _service.GetAllOrderItemAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPut("Update")]
    [ProducesResponseType(typeof(IEnumerable<OrderItems>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> UpdateProduct([FromBody] OrderItemUpdateDTO update)
    {
        try
        {
            var response = await _service.UpdateOrderItemAsync(update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpDelete("DeletePermanent")]
    [ProducesResponseType(typeof(IEnumerable<OrderItems>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> HardDeleteProduct(OrderItemDeleteDTO delete)
    {
        try
        {
            var response = await _service.HardDeleteOrderItemAsync(delete);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

}
