using Microsoft.AspNetCore.Identity;

namespace StillMeBackend.Gateway;

public class User : IdentityUser
{
    public byte[]? UserPicture { get; set; }
}