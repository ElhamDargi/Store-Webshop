using Store.Application.Interfaces;
using Store.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Commands.UpdateUser
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(UpdateUserServiceDTO request)
        {
            var User = _context.Users.Find(request.Id);
            if (User == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر موردنظر یافت نشد"
                };

            }
            else
            {
                User.FullName = request.FullName;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "تغییرات با موفقیت ثبت شد"
                };
            }
        }
    }
}
