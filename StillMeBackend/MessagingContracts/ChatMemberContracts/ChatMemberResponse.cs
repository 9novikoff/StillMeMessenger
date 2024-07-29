namespace MessagingContracts;

public class ChatMemberResponse
{
    public bool IsValid { get; set; } = true;
    public string? ErrorMessage { get; set; }
    public ChatMemberBase? Value { get; set; }
}