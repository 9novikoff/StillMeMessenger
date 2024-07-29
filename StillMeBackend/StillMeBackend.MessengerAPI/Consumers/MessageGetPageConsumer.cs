using MassTransit;
using MessagingContracts.MessageContracts;
using StillMeBackend.MessengerAPI.Services;

namespace StillMeBackend.MessengerAPI.Consumers;

public class MessageGetPageConsumer: IConsumer<MessageGetPage>
{
    private readonly MessageService _service;

    public MessageGetPageConsumer(MessageService service)
    {
        _service = service;
    }

    public async Task Consume(ConsumeContext<MessageGetPage> context)
    {
        await context.RespondAsync(new MessageListResponse{Content = _service.GetMessagePageForUserId(context.Message.UserId, context.Message.PageNumber, context.Message.PageSize).ToList()});
    }
}