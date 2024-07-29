using AutoMapper;
using MassTransit;
using MessagingContracts.MessageContracts;
using StillMeBackend.MessengerAPI.Services;

namespace StillMeBackend.MessengerAPI.Consumers;

public class MessageCreateConsumer: IConsumer<MessageCreate>
{
    private readonly MessageService _service;
    private readonly IMapper _mapper;

    public MessageCreateConsumer(MessageService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<MessageCreate> context)
    {
        await _service.AddAsync(context.Message);
    }
}