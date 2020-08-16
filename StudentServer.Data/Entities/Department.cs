using StudentAppServer.Data.Enums;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            InstructorDepartments = new HashSet<InstructorDepartment>();
            StudentDepartments = new HashSet<StudentDepartment>();
        }

        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<InstructorDepartment> InstructorDepartments { get; set; }
        public virtual ICollection<StudentDepartment> StudentDepartments { get; set; }
    }
}