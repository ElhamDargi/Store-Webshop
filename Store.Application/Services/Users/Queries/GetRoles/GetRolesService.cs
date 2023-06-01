using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.User.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _dbContext;
        public GetRolesService( IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResultDto<List<GetRolesServiceDTO>> Execute()
        {
            var result= _dbContext.Roles.Select(r => new GetRolesServiceDTO
            {

                Id = r.Id,
                Name = r.Name,
            }).ToList();

            return new ResultDto<List<GetRolesServiceDTO>>()
            {
                Data = result,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
