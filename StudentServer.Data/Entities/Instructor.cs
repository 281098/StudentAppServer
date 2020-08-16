using StudentAppServer.Data.Enums;
using System;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            Teaches = new HashSet<Teach>();
            InstructorNotifications = new HashSet<InstructorNotification>();
        }

        public string Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? BitrhDay { get; set; }
        public string Address { get; set; }
        public int? CardId { get; set; }
        public string Birthplace { get; set; }
        public string CreatedYear { get; set; }
        public string Avatar { get; set; }
        public decimal? Salary { get; set; }
        public Status Status { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public string InstructorDepartmentId { get; set; }
        public string DepartmentId { get; set; }
        public virtual InstructorDepartment InstructorDepartment { get; set; }

        public virtual ICollection<InstructorNotification> InstructorNotifications { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}