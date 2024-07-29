namespace MessagingContracts.MessageContracts;

public class MessageResponse
{
    public bool IsValid { get; set; } = true;
    public string? ErrorMessage { get; set; }
    public MessageBase? Value { get; set; } 
}