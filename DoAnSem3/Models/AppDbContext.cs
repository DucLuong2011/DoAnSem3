using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // khai báo các thuộc tính biểu diễn các tập thực thể
        public DbSet<About> abouts { get; set; }
        public DbSet<Banking> bankings { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<NetworkServiceProvider> networkServiceProviders { get; set; }
        public DbSet<Order> orders{ get; set; }
        public DbSet<FreeBack> freeBacks{ get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Product> products { get; set; }


    }
}
