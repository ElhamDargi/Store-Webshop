using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Context
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "Operator" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = "Customer" });


            //جلوگیری از تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();

            //اعمال فیلتر در جدول کاربران 
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsRemoved);
        }

    }
}
