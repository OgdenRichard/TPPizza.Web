using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPPizza.Web.DataAccessLayer.Entity
{
    public sealed class Dough
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DoughId { get; set; }

        [Required]
        [MaxLength(150)]
        public string DoughName { get; set; } = string.Empty;

        public ICollection<Pizza> Pizzas { get; set; } = [];
    }
}
