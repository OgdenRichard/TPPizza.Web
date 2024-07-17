using System.ComponentModel.DataAnnotations;
using TPPizza.Web.DataAccessLayer.Entity;

namespace TPPizza.Web.Models
{
    public class PizzaModel
    {
        public long PizzaId { get; set; }

        [Required(ErrorMessage = "Pizza name is required")]
        [StringLength(150, ErrorMessage = "Pizza name cannot be longer than 150 characters")]
        [Display(Name = "Pizza Name")]
       
        public string PizzaName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Dough selection is required")]
        [Display(Name = "Dough Type")]
        public long DoughId { get; set; }

         
      




    }
}
