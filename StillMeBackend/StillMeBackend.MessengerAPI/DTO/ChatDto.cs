using StillMeBackend.MessengerAPI.DAL;

namespace StillMeBackend.MessengerAPI.DTO;

public class ChatDto
{
    public string? Name { get; set; }
    public ChatType Type { get; set; }
}