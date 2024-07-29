using System.Security.Claims;
using MassTransit;
using MessagingContracts.ChatMessaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StillMeGateway.Controllers;

[ApiController]
[Route("chat")]
public class ChatController : ControllerBase
{
    private readonly IRequestClient<ChatListGet> _client;

    public ChatController(IRequestClient<ChatListGet> client)
    {
        _client = client;
    }
    
    [Authorize]
    [HttpGet("list")]
    public async Task<IActionResult> GetUserChats()
    {
        var userId = HttpContext.User.Claims.ToList()[0].Value;
        var response = await _client.GetResponse<ChatListResponse>(new ChatListGet { UserId = userId });
        return  Ok(response.Message.Content);
    }

}