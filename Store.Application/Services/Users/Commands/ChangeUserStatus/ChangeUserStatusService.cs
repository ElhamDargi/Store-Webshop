using Store.Application.Interfaces;
using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.ChangeUserStatus
{
    public class ChangeUserStatusService : IChangeUserStatusService
    {
        private readonly IDataBaseContext _context;
        public ChangeUserStatusService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            var user = _context.Users.Find(Id);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر موردنطر یافت نشد"
                };
            }
            else
            {
                user.IsActive = !user.IsActive;
                user.UpdateTime = DateTime.Now;
                _context.SaveChanges();

                string UserStatus=user.IsActive ? "فعال" : "غیرفعال";
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = $"کاربر با موفقیت {UserStatus} انجام شد"
                };
            }
        }
    }
}
