//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace StudentRegistration.Infrastructure.Repositories
//{
//    internal class StudentRepository
//    {
//    }
//}

using System.Collections.Generic;
using System.Linq;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;
using StudentRegistration.Infrastructure.Data;

namespace StudentRegistration.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                           .Where(s => !s.IsDeleted)
                           .ToList();
        }

        public Student? GetById(int id)
        {
            return _context.Students.
                FirstOrDefault(s => s.Id == id && !s.IsDeleted);
        }

        public void Add(Student student)
        {

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void SoftDelete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                student.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}
