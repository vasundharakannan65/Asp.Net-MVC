using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                if(entry.State == EntityState.Deleted && entity is Employee)
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("Status").SetValue(entity, 'D');
                } 

                
            }

            return base.SaveChanges();
        }
    }
}
