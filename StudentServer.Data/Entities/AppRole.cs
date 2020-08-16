using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class AppRole : IdentityRole<string>
    {
        public AppRole() : base()
        {
            Permissions = new HashSet<Permission>();
        }

        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}