using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back.Models;

namespace Back.Controllers
{
    public class ModeloEvaluativoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModeloEvaluativoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ModeloEvaluativo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelosEvaluativos.ToListAsync());
        }

        // GET: ModeloEvaluativo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeloEvaluativo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModeloEvaluativo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: ModeloEvaluativo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var modelo = await _context.ModelosEvaluativos.FindAsync(id);
            if (modelo == null)
                return NotFound();

            return View(modelo);
        }

        // POST: ModeloEvaluativo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ModeloEvaluativo modelo)
        {
            if (id != modelo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ModelosEvaluativos.Any(e => e.Id == id))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(modelo);
        }

        // POST: ModeloEvaluativo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var modelo = await _context.ModelosEvaluativos.FindAsync(id);
            if (modelo != null)
            {
                _context.ModelosEvaluativos.Remove(modelo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
