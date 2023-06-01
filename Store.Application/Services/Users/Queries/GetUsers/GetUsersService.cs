using Bugeto_Store.Common;
using Store.Application.Interfaces;
using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.User.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
             _context= context;
        }
        public ResultGetUser Execute(RequestInGetUsersService request)
        {
            var Query = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Searchkey))
            {
                Query = Query.Where(p => p.FullName.Contains(request.Searchkey) || p.Email.Contains(request.Searchkey));
            }
            int rowCount = 0;
            var result = Query.ToPaged(request.PageNum, 20, out rowCount).Select(p => new GetUsersServiceDTO
            {
                Email = p.Email,
                FullName = p.FullName,
                Id=p.Id,
                IsActive=p.IsActive,
            }).ToList();
            return new ResultGetUser
            {
                usersList= result,
                rowCount= rowCount
            };
        }
    }
}
