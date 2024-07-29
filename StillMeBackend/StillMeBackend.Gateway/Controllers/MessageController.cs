using AutoMapper;
using MassTransit;
using MessagingContracts.MessageContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StillMeBackend.Gateway.DTO;

namespace StillMeBackend.Gateway.Controllers;

[ApiController]
[Route("messages")]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly IPublishEndpoint _endpoint;
    private readonly IRequestClient<MessageGetPage> _messageGetPageClient;
    private readonly IMapper _mapper;

    public MessageController(IPublishEndpoint endpoint, IMapper mapper, IRequestClient<MessageGetPage> messageGetPageClient)
    {
        _endpoint = endpoint;
        _mapper = mapper;
        _messageGetPageClient = messageGetPageClient;
    }

    [HttpGet("page")]
    public async Task<IActionResult> GetMessagePage(int pageNumber, int pageSize)
    {
        var response = await _messageGetPageClient.GetResponse<MessageListResponse>(new MessageGetPage
            { UserId = HttpContext.User.Claims.ToList()[0].Value, PageNumber = pageNumber, PageSize = pageSize });

        return Ok(response.Message.Content);
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> PostMessage(MessageDto message)
    {
        var createContract = _mapper.Map<MessageCreate>(message);

        await _endpoint.Publish(createContract);

        return Accepted();
    }
}