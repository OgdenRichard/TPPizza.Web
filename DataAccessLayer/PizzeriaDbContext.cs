using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.InteropServices.Marshalling;
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

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dough>()
               .HasMany(d => d.Pizzas)
               .WithOne(p => p.Dough)
               .HasForeignKey(p => p.DoughId)
               .OnDelete(DeleteBehavior.Restrict);

            //Many TO Many Pizza - Ingredient
            modelBuilder.Entity<Pizza>()
            .HasMany(p => p.Ingredients)
            .WithMany(i => i.Pizzas)
            .UsingEntity(
                "PizzaIngredients",
                l => l.HasOne(typeof(Ingredient)).WithMany().HasForeignKey("IngredientId").HasPrincipalKey(nameof(Ingredient.IngredientId)).OnDelete(DeleteBehavior.Restrict),
                r => r.HasOne(typeof(Pizza)).WithMany().HasForeignKey("PizzaId").HasPrincipalKey(nameof(Pizza.PizzaId)).OnDelete(DeleteBehavior.Restrict),
                j => j.HasKey("PizzaId", "IngredientId"));


            //Unique Index of Pizza name 
            modelBuilder.Entity<Pizza>()
                 .HasIndex(p => p.PizzaName)
                 .IsUnique();
        }
    }
}