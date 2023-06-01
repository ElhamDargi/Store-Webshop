using Store.Application.Interfaces;
using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;
        public RemoveUserService(IDataBaseContext context)
        {
              _context= context;
        }
        public ResultDto Execute(long Id)
        {
            var user = _context.Users.Find(Id);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            else
            {
                user.IsRemoved = true;
                user.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "عملیات با موفقیت انجام شد"
                };
            }
        }
    }
}
