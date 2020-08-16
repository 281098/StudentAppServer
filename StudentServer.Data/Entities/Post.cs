using StudentAppServer.Data.Enums;
using System;

namespace StudentAppServer.Data.Entities
{
    public class Post
    {
        public string Id { get; set; }

        public string PostCategoryId { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }
        public Status Status { get; set; }

        public virtual PostCategory PostCategory { get; set; }
    }
}