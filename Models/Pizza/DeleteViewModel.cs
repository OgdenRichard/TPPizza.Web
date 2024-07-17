using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TPPizza.Web.DataAccessLayer.Entity;

namespace TPPizza.Web.Models.Pizza
{
    public class DeleteViewModel
    {
        public PizzaModel? Pizza { get; set; }

        public Dough? Dough { get; set; }

        public List<Ingredient>? Ingredients { get; set; }
    }
}
