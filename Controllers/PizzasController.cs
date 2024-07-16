using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPPizza.Web.DataAccessLayer;
using TPPizza.Web.DataAccessLayer.Entity;
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
            var pizzeriaDbContext = _context.Pizzas.Include(p => p.Dough);
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
            input.SelectableIngredients = this.GetSelectableIngredients();
             
            if (ModelState.IsValid)
            {
                var pizzaToCreate = new Pizza()
                {
                    PizzaName = input.Pizza.PizzaName,
                    DoughId =  input.Pizza.DoughId,
                    Ingredients = this.GetSelectedIngredients(input.SelectedIngredientIds)

                };
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName", pizza.DoughId);
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PizzaId,PizzaName,DoughId")] Pizza pizza)
        {
            if (id != pizza.PizzaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.PizzaId))
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
            ViewData["DoughId"] = new SelectList(_context.Doughs, "DoughId", "DoughName", pizza.DoughId);
            return View(pizza);
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

        private List<Ingredient> GetSelectedIngredients(List<String> selectedIngredientsIds)
        {
            return _context.Ingredients
                 .Where(i => selectedIngredientsIds.Contains(i.IngredientId.ToString()))
                 .ToList();
        }
    }
}
