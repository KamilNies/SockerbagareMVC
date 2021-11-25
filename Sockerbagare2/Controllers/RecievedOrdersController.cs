using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sockerbagare2.Context;
using Sockerbagare2.Models;

namespace Sockerbagare2.Controllers
{
    public class RecievedOrdersController : Controller
    {
        private readonly Sockerbagare2Context _context;

        public RecievedOrdersController(Sockerbagare2Context context)
        {
            _context = context;
        }

        // GET: RecievedOrders
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "recievingdate" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var sockerbagare2Context = _context.RecievedOrders.Include(r => r.Ingredient).Include(r => r.Provider);
            switch (sortOrder)
            {
                case "recievingdate":
                    return View(await sockerbagare2Context.OrderBy(x => x.RecievingDate).ToListAsync());
                case "ingredient":
                    return View(await sockerbagare2Context.OrderBy(x => x.Ingredient.IngredientName).ToListAsync());
                case "quantitykg":
                    return View(await sockerbagare2Context.OrderBy(x => x.QuantityKg).ToListAsync());
                case "manufacturingdate":
                    return View(await sockerbagare2Context.OrderBy(x => x.ManufacturingDate).ToListAsync());
                case "bestbeforedate":
                    return View(await sockerbagare2Context.OrderBy(x => x.BestBeforeDate).ToListAsync());
                case "provider":
                    return View(await sockerbagare2Context.OrderBy(x => x.Provider.ProviderName).ToListAsync());
                case "comments":
                    return View(await sockerbagare2Context.OrderBy(x => x.Comments).ToListAsync());
                default:
                    break;
            }

            //return View(await sockerbagare2Context.OrderBy(x => x.ManufacturingDate).ToListAsync());
            //return View(await sockerbagare2Context.OrderBy(x => x.RecievingDate).ToListAsync());
            //return View(await sockerbagare2Context.OrderBy(x => x.BestBeforeDate).ToListAsync());
            //return View(await sockerbagare2Context.OrderBy(x => x.QuantityKg).ToListAsync());
            //return View(await sockerbagare2Context.OrderBy(x => x.Provider.ProviderName).ToListAsync());
            //return View(await sockerbagare2Context.OrderBy(x => x.Ingredient.IngredientName).ToListAsync());
            return View(await sockerbagare2Context.ToListAsync());
        }

        // GET: RecievedOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recievedOrder = await _context.RecievedOrders
                .Include(r => r.Ingredient)
                .Include(r => r.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recievedOrder == null)
            {
                return NotFound();
            }

            return View(recievedOrder);
        }

        // GET: RecievedOrders/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "IngredientName");
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName");
            ViewBag.DateNow = DateTime.Now.ToString("g");
            return View();
        }

        // POST: RecievedOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProviderId,IngredientId,BatchNumber,ManufacturingDate,RecievingDate,BestBeforeDate,DeliveryNumber,QuantityKg,Comments")] RecievedOrder recievedOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recievedOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "IngredientName", recievedOrder.IngredientId);
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", recievedOrder.ProviderId);
            return View(recievedOrder);
        }

        // GET: RecievedOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recievedOrder = await _context.RecievedOrders.FindAsync(id);
            if (recievedOrder == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "IngredientName", recievedOrder.IngredientId);
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", recievedOrder.ProviderId);
            return View(recievedOrder);
        }

        // POST: RecievedOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProviderId,IngredientId,BatchNumber,ManufacturingDate,RecievingDate,BestBeforeDate,DeliveryNumber,QuantityKg,Comments")] RecievedOrder recievedOrder)
        {
            if (id != recievedOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recievedOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecievedOrderExists(recievedOrder.Id))
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
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "IngredientName", recievedOrder.IngredientId);
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "ProviderName", recievedOrder.ProviderId);
            return View(recievedOrder);
        }

        // GET: RecievedOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recievedOrder = await _context.RecievedOrders
                .Include(r => r.Ingredient)
                .Include(r => r.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recievedOrder == null)
            {
                return NotFound();
            }

            return View(recievedOrder);
        }

        // POST: RecievedOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recievedOrder = await _context.RecievedOrders.FindAsync(id);
            _context.RecievedOrders.Remove(recievedOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecievedOrderExists(int id)
        {
            return _context.RecievedOrders.Any(e => e.Id == id);
        }
    }
}
