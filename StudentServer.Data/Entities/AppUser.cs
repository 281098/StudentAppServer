using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            Students = new HashSet<Student>();
            Instructors = new HashSet<Instructor>();
            Admins = new HashSet<Admin>();
        }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}