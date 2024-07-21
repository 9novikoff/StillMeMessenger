namespace StillMeBackend.MessengerAPI.DAL;

public class Chat
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ChatType Type { get; set; }
    
    public virtual ICollection<ChatMember> ChatMembers { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
}