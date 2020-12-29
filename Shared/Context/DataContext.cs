using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared.Context
{
    public class DataContext : DbContext
    {
        // ======================================= //
        //          Relational DataSets
        // ======================================= //
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }
        // ======================================= //
        public DataContext(DbContextOptions options) : base(options) { }
        protected DataContext() { }
        // ======================================= //
    }
}