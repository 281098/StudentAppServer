namespace StudentAppServer.Data.Entities
{
    public class Take
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
        public string Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual Section Section { get; set; }
    }
}