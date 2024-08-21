using System.Security.Claims;
using MassTransit;
using MessagingContracts;
using MessagingContracts.ChatMessaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StillMeBackend.Gateway.Controllers;

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
    
    [Authorize]
    [HttpGet("create")]
    public async Task<IActionResult> CreateDialogChat()
    {
        var response = await _client.GetResponse<ChatResponse>(new ChatCreate { Type = ChatType.Personal});
        return response.Message.IsValid ? Ok(response.Message.Value) : BadRequest(response.Message.ErrorMessage);
    }

}