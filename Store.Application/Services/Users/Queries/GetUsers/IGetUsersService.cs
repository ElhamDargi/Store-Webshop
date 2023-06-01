using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.User.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUser Execute(RequestInGetUsersService request );
    }
}
