using Shared.Models.DTO.RequestDTO.Order;
using Shared.Models;
using FPTS_Training.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Shared.Models.DTO.RequestDTO.OrderItem;
using FPTS_Training.Services.OrderItemQueue;

namespace FPTS_Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _service;
    private readonly IOrderItemMessage _message;

    public OrderItemController(IOrderItemService service, IOrderItemMessage message)
    {
        _service = service;
        _message = message;
    }

    [HttpPost("AddOrderItem")]
    [ProducesResponseType(typeof(IEnumerable<OrderItems>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> AddBuyers([FromBody] OrderItemCreateDTO create)
    {
        try
        {
            var response = await _message.CreateOrderItemProducerAsync(create);
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

    [HttpGet("find-by-id")]
    [ProducesResponseType(typeof(IEnumerable<OrderItems>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<ActionResult<IEnumerable<OrderItems>>> FindOrderItemByIdAsync(string id)
    {
        try
        {
            var response = await _service.FindOrderItemByIdAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}
