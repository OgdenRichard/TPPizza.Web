using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TPPizza.Web.Models.Pizza
{
    public class CreateViewModel
    {
        public PizzaModel Pizza { get; set; }

        [BindNever]
        public List<SelectListItem> SelectableIngredients { get; set; } = new List<SelectListItem>();

        [Display(Name = "Select Ingredients")]
        [IngredientSelection(2, 5, ErrorMessage = "Please select between 2 and 5 ingredients.")]
        public List<string> SelectedIngredientIds { get; set; } = new List<string>();


    }
}
