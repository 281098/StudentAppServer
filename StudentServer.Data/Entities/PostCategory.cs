using StudentAppServer.Data.Enums;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class PostCategory
    {
        public PostCategory()
        {
            Posts = new HashSet<Post>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}