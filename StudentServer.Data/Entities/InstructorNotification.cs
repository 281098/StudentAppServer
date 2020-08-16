namespace StudentAppServer.Data.Entities
{
    public class InstructorNotification
    {
        public string InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

        public string NotificationId { get; set; }
        public virtual Notification Notification { get; set; }
    }
}