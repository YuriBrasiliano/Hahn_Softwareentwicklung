using Hahn_Softwareentwicklung.Application.Common.Interfaces.Persistence;
using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
}