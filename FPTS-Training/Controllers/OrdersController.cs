using FPTS_Training.Models.DTO.RequestDTO.Buyer;
using FPTS_Training.Models;
using FPTS_Training.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FPTS_Training.Models.DTO.RequestDTO.Order;
using FPTS_Training.Models.DTO.RequestDTO.Product;
using FPTS_Training.Services.OrderQueue;

namespace FPTS_Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;
    private readonly IOrderMessage _message;

    public OrdersController(IOrderService service, IOrderMessage message)
    {
        _service = service;
        _message = message;
    }

    [HttpPost("AddOrders")]
    [ProducesResponseType(typeof(IEnumerable<Orders>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> AddBuyers([FromBody] OrderCreateDTO create)
    {
        try
        {
            var response = await _message.CreateOrderProducerAsync(create);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }


    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(IEnumerable<Orders>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<ActionResult<IEnumerable<Orders>>> GetAllOrders()
    {
        try
        {
            var response = await _service.GetAllOrderAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPut("Update")]
    [ProducesResponseType(typeof(IEnumerable<Orders>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> UpdateProduct([FromBody] OrderUpdateDTO update)
    {
        try
        {
            var response = await _service.UpdateOrderAsync(update);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpDelete("DeletePermanent")]
    [ProducesResponseType(typeof(IEnumerable<Orders>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<IActionResult> HardDeleteProduct(OrderDeleteDTO delete)
    {
        try
        {
            var response = await _service.HardDeleteOrderAsync(delete);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    
}
