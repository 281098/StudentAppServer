namespace StudentAppServer.Data.Entities
{
    public class Admin
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}