using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPPizza.Web.DataAccessLayer;
using TPPizza.Web.DataAccessLayer.Entity;
using TPPizza.Web.Models;
using TPPizza.Web.Models.Pizza;

namespace TPPizza.Web.Controllers
{
    public class PizzasController : Controller
    {
        private readonly PizzeriaDbContext _context;

        public PizzasController(PizzeriaDbContext context)
        {
            _context = context;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
            var pizzeriaDbContext = _context.Pizzas.Include(d => d.Dough).Include(i => i.Ingredients);
            return View(await pizzeriaDbContext.ToListAsync());
        }

        // GET: Pizzas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizzas
                .Include(p => p.Dough)
                .FirstOrDefaultAsync(m => m.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            var vm = new CreateViewModel()
            {
                SelectableIngredients = this.GetSelectableIngredients()
            };
            ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName");
            return View(vm);
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pizza,SelectedIngredientIds")] CreateViewModel input)
        {
           
            
            if (ModelState.IsValid)
            {
                // The other solution is to make it as Validation Attribute !
                var existingPizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.PizzaName == input.Pizza.PizzaName);
                if (existingPizza != null)
                {
                    ModelState.AddModelError("Pizza.PizzaName", "A pizza with this name already exists.");
                    ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName", input.Pizza.DoughId);
                    input.SelectableIngredients = this.GetSelectableIngredients();
                    return View(input);
                }
                var pizzaToCreate = new Pizza()
                {
                    PizzaName = input.Pizza.PizzaName,
                    DoughId =  input.Pizza.DoughId,
                    Ingredients = this.GetSelectedIngredients(input.SelectedIngredientIds)

                };
                this._context.Pizzas.Add(pizzaToCreate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            input.SelectableIngredients = this.GetSelectableIngredients();
            ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName", input.Pizza.DoughId);
            return View(input);
        }

        // GET: Pizzas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizzas
                            .Include(p => p.Ingredients)
                            .FirstOrDefaultAsync(p => p.PizzaId == id);

            if (pizza == null)
            {
                return NotFound();
            }
            var vm = new EditViewModel()
            {
                Pizza = new PizzaModel()
                {
                    PizzaId = pizza.PizzaId,
                    PizzaName = pizza.PizzaName,
                    DoughId = pizza.DoughId,

                },
                SelectedIngredientIds = pizza.Ingredients.Select(i => i.IngredientId.ToString()).ToList(),
                SelectableIngredients = this.GetSelectableIngredients()
            };
            ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName", pizza.DoughId);

            return View(vm);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Pizza,SelectedIngredientIds")] EditViewModel input)
        {
            if (id != input.Pizza.PizzaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the existing pizza from the database
                    var pizzaToUpdate = await _context.Pizzas
                        .Include(p => p.Ingredients)
                        .FirstOrDefaultAsync(p => p.PizzaId == id);

                    if (pizzaToUpdate == null)
                    {
                        return NotFound();
                    }

                    // Check for name uniqueness (if name has changed)
                    if (pizzaToUpdate.PizzaName != input.Pizza.PizzaName)
                    {
                        var existingPizza = await _context.Pizzas
                            .FirstOrDefaultAsync(p => p.PizzaName == input.Pizza.PizzaName && p.PizzaId != id);
                        if (existingPizza != null)
                        {
                            ModelState.AddModelError("Pizza.PizzaName", "A pizza with this name already exists.");
                            input.SelectableIngredients = this.GetSelectableIngredients();
                            ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName", input.Pizza.DoughId);
                            return View(input);
                        }
                    }

                    // Update the pizza properties
                    pizzaToUpdate.PizzaName = input.Pizza.PizzaName;
                    pizzaToUpdate.DoughId = input.Pizza.DoughId;

                    // Update ingredients
                    var selectedIngredients = this.GetSelectedIngredients(input.SelectedIngredientIds);
                    var ingredientsToRemove = pizzaToUpdate.Ingredients.Where(i => !selectedIngredients.Contains(i)).ToList();
                    var ingredientsToAdd = selectedIngredients.Where(i => !pizzaToUpdate.Ingredients.Contains(i)).ToList();

                    foreach (var ingredient in ingredientsToRemove)
                    {
                        pizzaToUpdate.Ingredients.Remove(ingredient);
                    }
                    foreach (var ingredient in ingredientsToAdd)
                    {
                        pizzaToUpdate.Ingredients.Add(ingredient);
                    }

                    _context.Update(pizzaToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(input.Pizza.PizzaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            input.SelectableIngredients = this.GetSelectableIngredients();
            ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName", input.Pizza.DoughId);
            return View(input);
        }

        // GET: Pizzas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizzas
                .Include(p => p.Dough)
                .FirstOrDefaultAsync(m => m.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(long id)
        {
            return _context.Pizzas.Any(e => e.PizzaId == id);
        }

        private List<SelectListItem> GetSelectableIngredients()
        {

            return this._context.Ingredients.Select(i => new SelectListItem { Value = i.IngredientId.ToString(), Text = i.IngredientName }).ToList();
        }

        private  List<Ingredient> GetSelectedIngredients(List<String> selectedIngredientsIds)
        {
            return _context.Ingredients
                 .Where(i => selectedIngredientsIds.Contains(i.IngredientId.ToString()))
                 .ToList();
        }
    }
}
