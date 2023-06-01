using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.User.Commands.RegisterUser;
using Store.Application.Services.User.Queries.GetRoles;
using Store.Application.Services.User.Queries.GetUsers;
using Store.Application.Services.Users.Commands.ChangeUserStatus;
using Store.Application.Services.Users.Commands.RemoveUser;
using Store.Application.Services.Users.Commands.UpdateUser;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsers;
        private readonly IGetRolesService _getRoles;
        private readonly IRegisterUserService _registerUser;
        private readonly IRemoveUserService _removeUser;
        private readonly IChangeUserStatusService _userStatus;
        private readonly IUpdateUserService _updateUser;
        public UsersController(IGetUsersService getUsers, IGetRolesService getRoles, IRegisterUserService registerUser, IRemoveUserService removeUser, IChangeUserStatusService userStatus, IUpdateUserService updateUser)
        {
            _getUsers = getUsers;
            _getRoles = getRoles;
            _registerUser = registerUser;
            _removeUser = removeUser;
            _userStatus = userStatus;
            _updateUser = updateUser;

        }
        public IActionResult Index(string searchkey, int page = 1)
        {

            return View(_getUsers.Execute(new RequestInGetUsersService
            {
                PageNum = page,
                Searchkey = searchkey
            }));
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            var rolesList = _getRoles.Execute();
            ViewBag.Roles = new SelectList(rolesList.Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUser.Execute(new RequestINRegisterUserDTO
            {
                Email = Email,
                FullName = FullName,
                Password = Password,
                RePassword = RePassword,
                Roles = new List<RoleInRegisterUserDTO>()
                {
                    new RoleInRegisterUserDTO
                    {
                        RoleId= RoleId,
                    }
                }
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult RemoveUser(long Id)
        {
            return Json(_removeUser.Execute(Id));
        }
        [HttpPost]
        public IActionResult ChangeStatus(long Id)
        {
            return Json(_userStatus.Execute(Id));
        }

        [HttpPost]
        public IActionResult UpdateUser(long UserId, string FullName)
        {

            return Json(_updateUser.Execute(new UpdateUserServiceDTO
            {
                FullName = FullName,
                Id = UserId
            })
                );
        }
    }
}
