using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using SchoolLib.Data;

namespace SchoolLib.Contracts
{
    [DataContract]
    public class StudentDTO
    {
        public StudentDTO(Student student)
        {

            this.Id = student.Id;
            this.Name = student.Name;
            this.Surname = student.Surname;
            this.Document = student.Document;
            this.Course = new CourseDTO(student.Course);
            
            //TODO: Verificar que no haya referencia circular
            //this.FamilyRelatives = student.FamilyRelatives;

            this.FullName = student.FullName;
            this.Enabled = student.Enabled;

        }

        public static List<StudentDTO> ToStudentDTO(List<Student> students)
        {

            var studentsEnt = new List<StudentDTO>();
            foreach (var student in students)
            {
                studentsEnt.Add(new StudentDTO(student));
            }
            return studentsEnt;

        }

        public Student ToEntity()
        {
            return ToEntity(this);
        }

        public Student ToEntity(StudentDTO student)
        {
            var studentEnt = new Student();

            studentEnt.Id = student.Id;
            studentEnt.Name = student.Name;
            studentEnt.Surname = student.Surname;
            studentEnt.Document = student.Document;
            studentEnt.Course = student.Course.ToEntity();

            //TODO: Verificar que no haya referencia circular
            //studentEnt.FamilyRelatives = student.FamilyRelatives;

            studentEnt.Enabled = student.Enabled;

            return studentEnt;
        }

        public List<Student> ToEntities(List<StudentDTO> students)
        {
            var studentsEnt = new List<Student>();
            foreach (var student in students)
            {
                studentsEnt.Add(ToEntity(student));
            }
            return studentsEnt;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Document { get; set; }
        [DataMember]
        public CourseDTO Course { get; set; }
        [DataMember]
        public List<FamilyRelativeDTO> FamilyRelatives { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public bool Enabled { get; set; }

        

    }
}
