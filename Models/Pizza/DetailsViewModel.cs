using TPPizza.Web.DataAccessLayer.Entity;

namespace TPPizza.Web.Models.Pizza
{
    public class DetailsViewModel
    {
        public PizzaModel? Pizza { get; set; }

        public Dough? Dough { get; set; }

        public List<Ingredient>? Ingredients { get; set; }
    }
}
