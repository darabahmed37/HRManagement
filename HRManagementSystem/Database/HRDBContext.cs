using HRManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Database {
    public class HRDBContext : DbContext {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options) {
        }

        public DbSet<EmployeesModel> Employees { get; set; }
    }
}