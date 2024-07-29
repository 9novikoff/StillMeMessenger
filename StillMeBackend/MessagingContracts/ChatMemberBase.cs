namespace MessagingContracts;

public class ChatMemberBase
{
    public string UserId { get; set; }
    public int ChatId { get; set; }
    public MemberRole Role { get; set; }
}