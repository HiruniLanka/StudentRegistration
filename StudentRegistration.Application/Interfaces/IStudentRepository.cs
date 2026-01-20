using StudentRegistration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRegistration.Application.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void SoftDelete(int id);
    }
}


