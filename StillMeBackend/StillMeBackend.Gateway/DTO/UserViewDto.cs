namespace StillMeBackend.Gateway.DTO;

public class UserViewDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public byte[]? UserPicture { get; set; }
    public string PhoneNumber { get; set; }
}