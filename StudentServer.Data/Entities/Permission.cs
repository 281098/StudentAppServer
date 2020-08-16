namespace StudentAppServer.Data.Entities
{
    public class Permission
    {
        public string RoleId { get; set; }

        public bool CanCreate { set; get; }
        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }
        public bool CanDelete { set; get; }

        public virtual AppRole AppRole { get; set; }
    }
}