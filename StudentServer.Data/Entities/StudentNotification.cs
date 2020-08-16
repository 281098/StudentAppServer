namespace StudentAppServer.Data.Entities
{
    public class StudentNotification
    {
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string NotificationId { get; set; }
        public virtual Notification Notification { get; set; }
    }
}