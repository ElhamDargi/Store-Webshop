namespace Store.Application.Services.User.Commands.RegisterUser
{
    public class RequestINRegisterUserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RoleInRegisterUserDTO> Roles { get; set; }

    }
}
