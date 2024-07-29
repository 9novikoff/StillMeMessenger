namespace MessagingContracts;

public class MessageBase
{
    public string UserId { get; set; }
    public int ChatId { get; set; }
    public int? ContentId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}