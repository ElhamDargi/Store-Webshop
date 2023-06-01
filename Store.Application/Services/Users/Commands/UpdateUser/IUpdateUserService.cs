using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.UpdateUser
{
    public interface IUpdateUserService
    {
        ResultDto Execute(UpdateUserServiceDTO request);
    }

}
