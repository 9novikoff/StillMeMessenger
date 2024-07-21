using Microsoft.AspNetCore.Identity;

namespace StillMeGateway;

public class User : IdentityUser
{
    public byte[]? UserPicture { get; set; }
}