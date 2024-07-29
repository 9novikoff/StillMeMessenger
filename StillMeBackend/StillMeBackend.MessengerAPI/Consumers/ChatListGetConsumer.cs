using AutoMapper;
using MassTransit;
using MessagingContracts.ChatMessaging;
using StillMeBackend.MessengerAPI.Services;

namespace StillMeBackend.MessengerAPI.Consumers;

public class ChatListGetConsumer : IConsumer<ChatListGet>
{
    private ChatService _service;
    private IMapper _mapper;

    public ChatListGetConsumer(ChatService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    public async Task Consume(ConsumeContext<ChatListGet> context)
    {
        var result = _service.GetChatsByUserId(context.Message.UserId);

        var response = _mapper.Map<ChatListResponse>(result);

        await context.RespondAsync(response);
    }
}