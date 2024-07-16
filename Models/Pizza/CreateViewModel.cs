using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TPPizza.Web.Models.Pizza
{
    public class CreateViewModel
    {
        public PizzaModel Pizza { get; set; }
        public List<SelectListItem>  SelectableIngredients { get; set; }

        [Display(Name = "Ingredients")]
        public List<string> SelectedIngredientIds { get; set; } = new List<string>();


    }
}
