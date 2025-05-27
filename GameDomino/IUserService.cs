

namespace Domino
{
    public interface IUserService
    {
        bool UserExists(string login, string password, out Guid userId);
        Guid RegisterNewUser(string login, string password);
        bool LoginIsTaken(string login);
        bool ValidatePassword(string password);
        bool ValidateLogin(string login);
    }
}
