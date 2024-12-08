using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class ComunasController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: Comunas
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Comunas.Include(c => c.Departamento);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Comunas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var comuna = await _context.Comunas
            .Include(c => c.Departamento)
            .FirstOrDefaultAsync(m => m.ComunaId == id);
        if (comuna == null)
        {
            return NotFound();
        }

        return View(comuna);
    }

    // GET: Comunas/Create
    public IActionResult Create()
    {
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre");
        return View();
    }

    // POST: Comunas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ComunaId,Nombre,DepartamentoId")] Comuna comuna)
    {
        if (ModelState.IsValid)
        {
            _context.Add(comuna);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", comuna.DepartamentoId);
        return View(comuna);
    }

    // GET: Comunas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var comuna = await _context.Comunas.FindAsync(id);
        if (comuna == null)
        {
            return NotFound();
        }
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", comuna.DepartamentoId);
        return View(comuna);
    }

    // POST: Comunas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ComunaId,Nombre,DepartamentoId")] Comuna comuna)
    {
        if (id != comuna.ComunaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(comuna);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunaExists(comuna.ComunaId))
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
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", comuna.DepartamentoId);
        return View(comuna);
    }

    // GET: Comunas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var comuna = await _context.Comunas
            .Include(c => c.Departamento)
            .FirstOrDefaultAsync(m => m.ComunaId == id);
        if (comuna == null)
        {
            return NotFound();
        }

        return View(comuna);
    }

    // POST: Comunas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var comuna = await _context.Comunas.FindAsync(id);
        if (comuna != null)
        {
            _context.Comunas.Remove(comuna);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ComunaExists(int id)
    {
        return _context.Comunas.Any(e => e.ComunaId == id);
    }
}
