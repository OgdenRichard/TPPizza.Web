using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.InteropServices.Marshalling;
using TPPizza.Web.DataAccessLayer.Entity;

namespace TPPizza.Web.DataAccessLayer
{
    //Hello from test branch 
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
               l => l.HasOne(typeof(Ingredient)).WithMany().HasForeignKey("IngredientId").HasPrincipalKey(nameof(Ingredient.IngredientId)).OnDelete(DeleteBehavior.Cascade),
               r => r.HasOne(typeof(Pizza)).WithMany().HasForeignKey("PizzaId").HasPrincipalKey(nameof(Pizza.PizzaId)).OnDelete(DeleteBehavior.Cascade),
               j => j.HasKey("PizzaId", "IngredientId"));

            //Unique Index of Pizza name
            modelBuilder.Entity<Pizza>()
                 .HasIndex(p => p.PizzaName)
                 .IsUnique();

            // Dough seed data
            modelBuilder.Entity<Dough>()
                .HasData(
                    new Dough() { DoughId = 1, DoughName = "Neapolitan" },
                    new Dough() { DoughId = 2, DoughName = "New York Style" },
                    new Dough() { DoughId = 3, DoughName = "Chicago Deep Dish" },
                    new Dough() { DoughId = 4, DoughName = "Sicilian" },
                    new Dough() { DoughId = 5, DoughName = "Whole Wheat" },
                    new Dough() { DoughId = 6, DoughName = "Gluten-Free" },
                    new Dough() { DoughId = 7, DoughName = "Sourdough" },
                    new Dough() { DoughId = 8, DoughName = "Cauliflower" }
                );

            // Ingredient seed data
            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient { IngredientId = 1, IngredientName = "Tomato Sauce" },
                    new Ingredient { IngredientId = 2, IngredientName = "Mozzarella Cheese" },
                    new Ingredient { IngredientId = 3, IngredientName = "Pepperoni" },
                    new Ingredient { IngredientId = 4, IngredientName = "Mushrooms" },
                    new Ingredient { IngredientId = 5, IngredientName = "Bell Peppers" },
                    new Ingredient { IngredientId = 6, IngredientName = "Onions" },
                    new Ingredient { IngredientId = 7, IngredientName = "Olives" },
                    new Ingredient { IngredientId = 8, IngredientName = "Sausage" },
                    new Ingredient { IngredientId = 9, IngredientName = "Ham" },
                    new Ingredient { IngredientId = 10, IngredientName = "Pineapple" },
                    new Ingredient { IngredientId = 11, IngredientName = "Bacon" },
                    new Ingredient { IngredientId = 12, IngredientName = "Spinach" },
                    new Ingredient { IngredientId = 13, IngredientName = "Garlic" },
                    new Ingredient { IngredientId = 14, IngredientName = "Basil" },
                    new Ingredient { IngredientId = 15, IngredientName = "Ricotta Cheese" }
                );
        }
    }
}