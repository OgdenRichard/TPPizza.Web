using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPPizza.Web.DataAccessLayer.Entity
{
    public sealed class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IngredientId {  get; set; }

        [Required]
        [MaxLength(150)]
        public string IngredientName { get; set; } = string.Empty;

        public ICollection<Pizza> Pizzas { get; set; } = [];
    }
}
