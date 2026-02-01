using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Interfaces
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);
        User? GetByResetToken(string token);
        void Add(User user);
        void Update(User user);
    }
}
