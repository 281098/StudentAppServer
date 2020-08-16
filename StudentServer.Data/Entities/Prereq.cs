using StudentAppServer.Data.Enums;

namespace StudentAppServer.Data.Entities
{
    public class Prereq
    {
        public string CourseId { get; set; }
        public string PrereqId { get; set; }
        public Status Status { get; set; }

        public virtual Course Course { get; set; }
    }
}