namespace StillMeBackend.Gateway.DTO;

public class MessageDto
{
    public string UserId { get; set; }
    public int ChatId { get; set; }
    public int? ContentId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}