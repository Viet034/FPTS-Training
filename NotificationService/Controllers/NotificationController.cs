using Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Service;
using Shared.Models.DTO.RequestDTO.Notification;
using System.Net;

namespace NotificationService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationController(INotificationService service)
    {
        _service = service;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(IEnumerable<Orders>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]

    public async Task<ActionResult<Orders>> GetNotification()
    {
        try
        {
            var response = await _service.NotificationUser();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}
