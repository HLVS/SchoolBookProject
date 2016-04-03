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
    public class CourseDTO
    {
        public CourseDTO(Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;
            this.Enabled = course.Enabled;
        }

        public List<CourseDTO> ToCourseDTO(List<Course> courses)
        {
            var courseEnt = new List<CourseDTO>();
            foreach (var course in courses)
            {
                courseEnt.Add(new CourseDTO(course));
            }
            return courseEnt;
        }

        public Course ToEntity()
        {
            return ToEntity(this);
        }

        public Course ToEntity(CourseDTO course)
        {
            var courseEnt = new Course();

            courseEnt.Id = course.Id;
            courseEnt.Name = course.Name;
            courseEnt.Enabled = course.Enabled;

            return courseEnt;
        }

        public List<Course> ToEntities(List<CourseDTO> courses)
        {
            var courseEnt = new List<Course>();
            foreach (var course in courses)
            {
                courseEnt.Add(ToEntity(course));
            }
            return courseEnt;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Enabled { get; set; }
    }
}
