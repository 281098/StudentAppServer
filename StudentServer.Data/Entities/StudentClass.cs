using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class StudentClass
    {
        public StudentClass()
        {
            Students = new HashSet<Student>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string DepartmentId { get; set; }
        public string StudentDepartmentId { get; set; }
        public virtual StudentDepartment StudentDepartment { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}