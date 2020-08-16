using StudentAppServer.Data.Enums;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class StudentDepartment
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}