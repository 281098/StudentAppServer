using StudentAppServer.Data.Enums;
using System.Collections.Generic;

namespace StudentAppServer.Data.Entities
{
    public class Section
    {
        public Section()
        {
            Takes = new HashSet<Take>();
            Teaches = new HashSet<Teach>();
        }

        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }

        public string Building { get; set; }
        public string RoomNumber { get; set; }

        public string TimeSlotId { get; set; }

        public Status Status { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<Take> Takes { get; set; }
        public virtual ICollection<Teach> Teaches { get; set; }
    }
}