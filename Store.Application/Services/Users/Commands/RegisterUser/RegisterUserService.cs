using Store.Application.Interfaces;
using Store.Common.DTO;
using Store.Domain.Entities.User;

namespace Store.Application.Services.User.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDTO> Execute(RequestINRegisterUserDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            Id = 0
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            Id = 0
                        },
                        IsSuccess = false,
                        Message = "ایمیل را وارد نمایید"
                    };
                }
              
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            Id = 0
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDto<ResultRegisterUserDTO>()
                    {
                        Data = new ResultRegisterUserDTO()
                        {
                            Id = 0
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن یکسان نیستند"
                    };
                }
                var user = new Store.Domain.Entities.User.User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    Password=request.Password,
                    InsertTime=DateTime.Now
                };

                List<UserInRole> userInRole = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var role = _context.Roles.Find(item.RoleId);


                    userInRole.Add(new UserInRole
                    {
                        User = user,
                        UserId = user.Id,
                        Role = role,
                        RoleId = role.Id
                    });
                }
                user.UserInRoles = userInRole;

                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDto<ResultRegisterUserDTO>()
                {
                    Data = new ResultRegisterUserDTO()
                    {
                        Id = user.Id
                    },
                    IsSuccess = true,
                    Message = "عملیات با موفقیت انجام شد"

                };
            }
            catch (Exception)
            {


                return new ResultDto<ResultRegisterUserDTO>()
                {
                    Data = new ResultRegisterUserDTO()
                    {
                        Id = 0
                    },
                    IsSuccess = false,
                    Message = "عملیات با موفقیت انجام نشد"

                };
            }
        }
    }
}
