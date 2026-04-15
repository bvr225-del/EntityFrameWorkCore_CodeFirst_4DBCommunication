using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect
{
    public class DepartmentContext:DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        {

        }
        //you need to register model class into DbSet<>placeholder section.
        public DbSet<Department123> Department123 { get; set; }

    }
}
