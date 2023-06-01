namespace Store.Domain.Entities.User
{
    public class Role 
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public  ICollection<UserInRole> UserInRoles { get; set; }

    }
}
