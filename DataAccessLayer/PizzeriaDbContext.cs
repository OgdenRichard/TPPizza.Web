using Microsoft.EntityFrameworkCore;
using System;
using TPPizza.Web.DataAccessLayer.Entity;

namespace TPPizza.Web.DataAccessLayer
{
    public sealed class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Dough> Doughs { get; set; }

    }
}
