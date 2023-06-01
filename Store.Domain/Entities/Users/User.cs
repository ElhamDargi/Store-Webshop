using Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.User
{
    public class User:BaseEntityNoId
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }=true;
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
