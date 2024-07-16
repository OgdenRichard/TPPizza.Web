using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPPizza.Web.DataAccessLayer.Entity
{

    
    public sealed class Pizza
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PizzaId { get; set; }

        [Required]
        [MaxLength(150)]
        public string PizzaName { get; set; } = String.Empty;

     
        [Required]
        public long DoughId { get; set; }
    
        public Dough Dough { get; set; } = default!;

        public ICollection<Ingredient> Ingredients { get; set; } = [];


    }
}
