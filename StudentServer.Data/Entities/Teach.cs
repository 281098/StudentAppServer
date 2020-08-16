namespace StudentAppServer.Data.Entities
{
    public class Teach
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Section Section { get; set; }
    }
}