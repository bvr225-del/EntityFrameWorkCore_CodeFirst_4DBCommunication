using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect
{
    public class OrderContext:DbContext
    {    //if you create any context class must be inherit from DbContext class.
         //DbContext class having Savechanges() method,it is used to save the data perminently.

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        //you need to register model class into DbSet<>placeholder section.
        public DbSet<Order> Orders123 { get; set; }

    }
}
