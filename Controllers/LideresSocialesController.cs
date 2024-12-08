using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class LideresSocialesController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: LideresSociales
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.LiderSocials.Include(l => l.Barrio);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: LideresSociales/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var liderSocial = await _context.LiderSocials
            .Include(l => l.Barrio)
            .FirstOrDefaultAsync(m => m.LiderSocialId == id);
        if (liderSocial == null)
        {
            return NotFound();
        }

        return View(liderSocial);
    }

    // GET: LideresSociales/Create
    public IActionResult Create()
    {
        ViewData["BarrioId"] = new SelectList(_context.Barrios, "BarrioId", "Nombre");
        return View();
    }

    // POST: LideresSociales/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LiderSocialId,Nombre,BarrioId")] LiderSocial liderSocial)
    {
        if (ModelState.IsValid)
        {
            _context.Add(liderSocial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["BarrioId"] = new SelectList(_context.Barrios, "BarrioId", "Nombre", liderSocial.BarrioId);
        return View(liderSocial);
    }

    // GET: LideresSociales/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var liderSocial = await _context.LiderSocials.FindAsync(id);
        if (liderSocial == null)
        {
            return NotFound();
        }
        ViewData["BarrioId"] = new SelectList(_context.Barrios, "BarrioId", "Nombre", liderSocial.BarrioId);
        return View(liderSocial);
    }

    // POST: LideresSociales/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LiderSocialId,Nombre,BarrioId")] LiderSocial liderSocial)
    {
        if (id != liderSocial.LiderSocialId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(liderSocial);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiderSocialExists(liderSocial.LiderSocialId))
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
        ViewData["BarrioId"] = new SelectList(_context.Barrios, "BarrioId", "Nombre", liderSocial.BarrioId);
        return View(liderSocial);
    }

    // GET: LideresSociales/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var liderSocial = await _context.LiderSocials
            .Include(l => l.Barrio)
            .FirstOrDefaultAsync(m => m.LiderSocialId == id);
        if (liderSocial == null)
        {
            return NotFound();
        }

        return View(liderSocial);
    }

    // POST: LideresSociales/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var liderSocial = await _context.LiderSocials.FindAsync(id);
        if (liderSocial != null)
        {
            _context.LiderSocials.Remove(liderSocial);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LiderSocialExists(int id)
    {
        return _context.LiderSocials.Any(e => e.LiderSocialId == id);
    }
}
