//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace StudentRegistration.Application.Services
//{
//    internal class StudentService
//    {
//    }
//}

using System;
using System.Collections.Generic;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Application.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _repository.GetAll();
        }

        public Student GetStudent(int id)
        {
            return _repository.GetById(id);
        }

        public void AddStudent(Student student)
        {
            student.CreatedDate = DateTime.Now;
            student.UpdatedDate = DateTime.Now;
            student.IsDeleted = false;

            _repository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            student.UpdatedDate = DateTime.Now;
            _repository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.SoftDelete(id);
        }
    }
}
