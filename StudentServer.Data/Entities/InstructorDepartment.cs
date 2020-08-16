using StudentAppServer.Data.Enums;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class InstructorDepartment
    {
        public InstructorDepartment()
        {
            Instructors = new HashSet<Instructor>();
        }

        public string Id { get; set; }

        public string DepartmentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}