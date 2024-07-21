namespace StillMeBackend.MessengerAPI.DAL;

public class ChatMember
{
    public string UserId { get; set; }
    public int ChatId { get; set; }
    public MemberRole Role { get; set; }
    
    public virtual Chat Chat { get; set; }
}