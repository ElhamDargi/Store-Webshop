namespace Store.Application.Services.User.Queries.GetUsers
{
    public class ResultGetUser
    {
        public List<GetUsersServiceDTO> usersList { get; set; }
        public int rowCount { get; set; }
    }
}
