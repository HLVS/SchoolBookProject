using System;
using System.Collections.Generic;
using System.Linq;
using SchoolLib.Contracts;
using SchoolLib.Data;

namespace SchoolLib.Services
{
    public class StudentManager : IStudentService
    {
        IStudentRepository _studentRepository = null;

        public StudentManager()
        {
        }

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public List<StudentDTO> GetStudents()
        {
            var students = StudentDTO.ToStudentDTO(_studentRepository.Get().ToList());
            return students;
        }


    }
    
}
