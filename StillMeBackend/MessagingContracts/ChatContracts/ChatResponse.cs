namespace MessagingContracts.ChatMessaging;

public class ChatResponse
{
    public bool IsValid { get; set; } = true;
    public string? ErrorMessage { get; set; }
    public ChatBase? Value { get; set; }
}