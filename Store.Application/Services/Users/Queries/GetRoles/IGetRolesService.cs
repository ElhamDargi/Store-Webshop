using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.User.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<GetRolesServiceDTO>> Execute();
    }
}
