namespace StillMeBackend.MessengerAPI.DAL;

public class Message
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ChatId { get; set; }
    public int? ContentId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public virtual Chat Chat { get; set; }
}