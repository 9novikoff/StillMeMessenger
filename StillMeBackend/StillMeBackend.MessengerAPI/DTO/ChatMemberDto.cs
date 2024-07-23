using StillMeBackend.MessengerAPI.DAL;

namespace StillMeBackend.MessengerAPI.DTO;

public class ChatMemberDto
{
    public string UserId { get; set; }
    public int ChatId { get; set; }
    public MemberRole Role { get; set; }
}