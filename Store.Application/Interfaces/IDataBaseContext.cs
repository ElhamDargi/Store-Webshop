using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IDataBaseContext
    {
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UsersInRoles { get; set; }

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
