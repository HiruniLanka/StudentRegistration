using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;
using StudentRegistration.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistration.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // --------------------
        // Get user by Email
        // --------------------
        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        // --------------------
        // Add new user
        // --------------------
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // --------------------
        // Get user by Reset Token
        // --------------------
        public User? GetByResetToken(string token)
        {
            return _context.Users.FirstOrDefault(u => u.ResetToken == token);
        }

        // --------------------
        // Update user
        // --------------------
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
