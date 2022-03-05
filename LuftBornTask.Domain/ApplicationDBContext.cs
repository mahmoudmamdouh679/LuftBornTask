using LuftBornTask.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBornTask.Domain
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "97f873e0-6e44-4fe1-88b1-f1659e98a2cc", Email = "admin@task.com", PasswordHash = "APvPdhTRB8g9uf327snwBoepFblN/KO5xv69GEVTdVVjvYkdVFNXnYqWcncJq8C+6g==" },
                new ApplicationUser { Id = "1ea5b2e2-cb34-46c4-a89f-d66a52d2ecbf", Email = "user@task.com", PasswordHash = "APvPdhTRB8g9uf327snwBoepFblN/KO5xv69GEVTdVVjvYkdVFNXnYqWcncJq8C+6g==" }
                );
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "SysAdmin", NormalizedName = "SYSADMIN" },
                new IdentityRole { Id = "2", Name = "HRManager", NormalizedName = "HRADMIN" },
                new IdentityRole { Id = "3", Name = "HR", NormalizedName = "HR" },
                new IdentityRole { Id = "4", Name = "Attendance", NormalizedName = "ATTENDANCE" },
                new IdentityRole { Id = "5", Name = "PayRoll", NormalizedName = "PAYROLL" },
                new IdentityRole { Id = "6", Name = "User", NormalizedName = "USER" }
                );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "97f873e0-6e44-4fe1-88b1-f1659e98a2cc", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "1ea5b2e2-cb34-46c4-a89f-d66a52d2ecbf", RoleId = "6" }
                );
            builder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "System",
                    LastName = "Admin",
                    //BirthDate = DateTime.Now,
                    NationalId = "12345678908523",
                    CreatedDate = DateTime.Now,
                    CreatedEmpId = 1,
                    //UserId = "97f873e0-6e44-4fe1-88b1-f1659e98a2cc"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "User",
                    LastName = "User",
                    //BirthDate = DateTime.Now,
                    NationalId = "54785678908523",
                    CreatedDate = DateTime.Now,
                    CreatedEmpId = 1,
                    //UserId = "1ea5b2e2-cb34-46c4-a89f-d66a52d2ecbf"
                }
                );
        }
    }
}
