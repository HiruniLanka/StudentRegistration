namespace StudentRegistration.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? ResetToken { get; set; }

        public DateTime? ResetTokenExpiry { get; set; }
    }
}
