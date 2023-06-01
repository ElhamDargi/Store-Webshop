namespace Store.Application.Services.User.Queries.GetUsers
{
    public class GetUsersServiceDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
