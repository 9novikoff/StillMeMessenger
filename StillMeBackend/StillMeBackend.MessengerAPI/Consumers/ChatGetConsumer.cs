using AutoMapper;
using MassTransit;
using MessagingContracts;
using MessagingContracts.ChatMessaging;
using MessagingContracts.MessageContracts;
using Microsoft.AspNetCore.Mvc;
using StillMeBackend.MessengerAPI.Services;

namespace StillMeBackend.MessengerAPI.Consumers;

public class ChatGetConsumer: IConsumer<ChatGet>
{
    private ChatService _service;
    private IMapper _mapper;

    public ChatGetConsumer(ChatService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<ChatGet> context)
    {
        var id = context.Message.Id;
        var result = await _service.GetByIdAsync(id);

        var response = _mapper.Map<ChatResponse>(result);
        
        await context.RespondAsync(response);
    }
}