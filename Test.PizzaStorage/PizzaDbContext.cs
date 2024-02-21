using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.PizzaStorage
{
    public class PizzaDbContext : DbContext
    {
        private readonly ILogger<PizzaDbContext> logger;

        public DbSet<Pizza> Pizzas { get; set; }

        public PizzaDbContext(ILogger<PizzaDbContext> logger, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.logger = logger;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = Pizza.db");
        }
    }
}
