using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class CiudadesController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: Ciudades
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Ciudades.Include(c => c.Departamento);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Ciudades/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ciudad = await _context.Ciudades
            .Include(c => c.Departamento)
            .FirstOrDefaultAsync(m => m.CiudadId == id);
        if (ciudad == null)
        {
            return NotFound();
        }

        return View(ciudad);
    }

    // GET: Ciudades/Create
    public IActionResult Create()
    {
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre");
        return View();
    }

    // POST: Ciudades/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CiudadId,Nombre,DepartamentoId")] Ciudad ciudad)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", ciudad.DepartamentoId);
        return View(ciudad);
    }

    // GET: Ciudades/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ciudad = await _context.Ciudades.FindAsync(id);
        if (ciudad == null)
        {
            return NotFound();
        }
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", ciudad.DepartamentoId);
        return View(ciudad);
    }

    // POST: Ciudades/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CiudadId,Nombre,DepartamentoId")] Ciudad ciudad)
    {
        if (id != ciudad.CiudadId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ciudad);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadExists(ciudad.CiudadId))
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
        ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "Nombre", ciudad.DepartamentoId);
        return View(ciudad);
    }

    // GET: Ciudades/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ciudad = await _context.Ciudades
            .Include(c => c.Departamento)
            .FirstOrDefaultAsync(m => m.CiudadId == id);
        if (ciudad == null)
        {
            return NotFound();
        }

        return View(ciudad);
    }

    // POST: Ciudades/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var ciudad = await _context.Ciudades.FindAsync(id);
        if (ciudad != null)
        {
            _context.Ciudades.Remove(ciudad);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CiudadExists(int id)
    {
        return _context.Ciudades.Any(e => e.CiudadId == id);
    }
}
