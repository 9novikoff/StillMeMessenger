namespace StillMeBackend.Gateway;

public class UserRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public UserRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public IQueryable<User> GetUsers()
    {
        return _identityDbContext.Users;
    }
}