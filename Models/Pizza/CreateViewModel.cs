using Microsoft.AspNetCore.Mvc.Rendering;

namespace TPPizza.Web.Models.Pizza
{
    public class CreateViewModel
    {
        public PizzaModel Pizza { get; set; }
        public List<SelectListItem>  SelectedIngredients { get; set; }
        public List<long> SelectedIngredientIds { get; set; } = new List<long>();


    }
}
