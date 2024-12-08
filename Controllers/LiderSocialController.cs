using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class LiderSocialController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: LiderSocial
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.LiderSocials.Include(l => l.Barrio).Include(l => l.Ciudad);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: LiderSocial/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var liderSocial = await _context.LiderSocials
            .Include(l => l.Barrio)
            .Include(l => l.Ciudad)
            .FirstOrDefaultAsync(m => m.LiderSocialId == id);
        if (liderSocial == null)
        {
            return NotFound();
        }

        return View(liderSocial);
    }

    // GET: LiderSocial/Create
    public IActionResult Create()
    {
        ViewData["BarrioId"] = new SelectList(_context.Barrios, "BarrioId", "Nombre");
        ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "Nombre");
        return View();
    }

    // POST: LiderSocial/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LiderSocialId,Nombre,BarrioId,CiudadId")] LiderSocial liderSocial)
    {
        if (ModelState.IsValid)
        {
            _context.Add(liderSocial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["BarrioId"] = new SelectList(_context.Barrios, "BarrioId", "Nombre", liderSocial.BarrioId);
        ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "Nombre", liderSocial.CiudadId);
        return View(liderSocial);
    }

    // GET: LiderSocial/Edit/5
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
        ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "Nombre", liderSocial.CiudadId);
        return View(liderSocial);
    }

    // POST: LiderSocial/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LiderSocialId,Nombre,BarrioId,CiudadId")] LiderSocial liderSocial)
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
        ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "Nombre", liderSocial.CiudadId);
        return View(liderSocial);
    }

    // GET: LiderSocial/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var liderSocial = await _context.LiderSocials
            .Include(l => l.Barrio)
            .Include(l => l.Ciudad)
            .FirstOrDefaultAsync(m => m.LiderSocialId == id);
        if (liderSocial == null)
        {
            return NotFound();
        }

        return View(liderSocial);
    }

    // POST: LiderSocial/Delete/5
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
