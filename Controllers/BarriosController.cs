using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class BarriosController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: Barrios
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Barrios.Include(b => b.Comuna);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Barrios/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barrio = await _context.Barrios
            .Include(b => b.Comuna)
            .FirstOrDefaultAsync(m => m.BarrioId == id);
        if (barrio == null)
        {
            return NotFound();
        }

        return View(barrio);
    }

    // GET: Barrios/Create
    public IActionResult Create()
    {
        ViewData["ComunaId"] = new SelectList(_context.Comunas, "ComunaId", "Nombre");
        return View();
    }

    // POST: Barrios/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BarrioId,Nombre,ComunaId")] Barrio barrio)
    {
        if (ModelState.IsValid)
        {
            _context.Add(barrio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ComunaId"] = new SelectList(_context.Comunas, "ComunaId", "Nombre", barrio.ComunaId);
        return View(barrio);
    }

    // GET: Barrios/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barrio = await _context.Barrios.FindAsync(id);
        if (barrio == null)
        {
            return NotFound();
        }
        ViewData["ComunaId"] = new SelectList(_context.Comunas, "ComunaId", "Nombre", barrio.ComunaId);
        return View(barrio);
    }

    // POST: Barrios/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("BarrioId,Nombre,ComunaId")] Barrio barrio)
    {
        if (id != barrio.BarrioId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(barrio);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarrioExists(barrio.BarrioId))
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
        ViewData["ComunaId"] = new SelectList(_context.Comunas, "ComunaId", "Nombre", barrio.ComunaId);
        return View(barrio);
    }

    // GET: Barrios/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barrio = await _context.Barrios
            .Include(b => b.Comuna)
            .FirstOrDefaultAsync(m => m.BarrioId == id);
        if (barrio == null)
        {
            return NotFound();
        }

        return View(barrio);
    }

    // POST: Barrios/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var barrio = await _context.Barrios.FindAsync(id);
        if (barrio != null)
        {
            _context.Barrios.Remove(barrio);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BarrioExists(int id)
    {
        return _context.Barrios.Any(e => e.BarrioId == id);
    }
}
