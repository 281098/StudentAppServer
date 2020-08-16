using StudentAppServer.Data.Enums;
using System;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class Student
    {
        public Student()
        {
            Takes = new HashSet<Take>();
            ToeicPoints = new HashSet<ToeicPoint>();
            StudentNotifications = new HashSet<StudentNotification>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int? TotCred { get; set; }
        public string Password { get; set; }
        public DateTime? BitrhDay { get; set; }
        public string Address { get; set; }
        public int? CardId { get; set; }
        public string Birthplace { get; set; }
        public string Avatar { get; set; }
        public Status Status { get; set; }
        public string CreatedYear { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public string StudentClassId { get; set; }
        public string StudentDepartmentId { get; set; }
        public string DepartmentId { get; set; }
        public virtual StudentClass StudentClass { get; set; }

        public virtual ICollection<Take> Takes { get; set; }
        public virtual ICollection<StudentNotification> StudentNotifications { get; set; }
        public virtual ICollection<ToeicPoint> ToeicPoints { get; set; }
    }
}