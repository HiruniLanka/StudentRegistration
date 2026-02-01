using StudentRegistration.Application.Interfaces;
using StudentRegistration.Application.Security;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // --------------------
        // REGISTER
        // --------------------
        public void Register(User user, string password)
        {
            user.PasswordHash = PasswordHelper.Hash(password);
            _userRepository.Add(user);
        }

        // --------------------
        // LOGIN
        // --------------------
        public User? Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
                return null;

            return PasswordHelper.Verify(password, user.PasswordHash)
                ? user
                : null;
        }

        // --------------------
        // RESET PASSWORD (BY EMAIL ONLY)
        // --------------------
        public bool ResetPasswordByEmail(string email, string newPassword)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
                return false;

            user.PasswordHash = PasswordHelper.Hash(newPassword);
            _userRepository.Update(user);

            return true;
        }
    }
}
