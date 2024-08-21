using MassTransit;
using MessagingContracts;
using MessagingContracts.ChatMessaging;
using Microsoft.AspNetCore.Mvc;

namespace StillMeBackend.Gateway.Controllers;

[ApiController]
[Route("chat-member")]
public class ChatMemberController: ControllerBase
{
    private readonly IPublishEndpoint _endpoint;

    public ChatMemberController(IPublishEndpoint endpoint)
    {
        _endpoint = endpoint;
    }

    public async Task<IActionResult> AddChatMembers(string userId, int chatId)
    {
        var creatorId = HttpContext.User.Claims.ToList()[0].Value;
        await _endpoint.Publish(new ChatMemberCreate { UserId = userId, ChatId = chatId});
        await _endpoint.Publish(new ChatMemberCreate { UserId = creatorId, ChatId = chatId});

        return Accepted();
    }
}