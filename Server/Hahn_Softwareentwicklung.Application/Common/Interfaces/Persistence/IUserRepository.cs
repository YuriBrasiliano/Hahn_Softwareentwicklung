using Hahn_Softwareentwicklung.Domain.Entities;

namespace Hahn_Softwareentwicklung.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

   List<User> GetAllUsers();

    void Add(User user);
}