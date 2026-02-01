//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace StudentRegistration.Infrastructure.Data
//{
//    internal class AppDbContext
//    {
//    }
//}

using Microsoft.EntityFrameworkCore;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
