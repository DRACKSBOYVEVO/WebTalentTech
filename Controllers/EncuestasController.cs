using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class EncuestasController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: Encuestas
    public async Task<IActionResult> Index()
    {
        return View(await _context.Encuestas.ToListAsync());
    }

    // GET: Encuestas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var encuesta = await _context.Encuestas
            .FirstOrDefaultAsync(m => m.EncuestaId == id);
        if (encuesta == null)
        {
            return NotFound();
        }

        return View(encuesta);
    }

    // GET: Encuestas/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Encuestas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EncuestaId,Descripcion")] Encuesta encuesta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(encuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(encuesta);
    }

    // GET: Encuestas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var encuesta = await _context.Encuestas.FindAsync(id);
        if (encuesta == null)
        {
            return NotFound();
        }
        return View(encuesta);
    }

    // POST: Encuestas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EncuestaId,Descripcion")] Encuesta encuesta)
    {
        if (id != encuesta.EncuestaId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(encuesta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncuestaExists(encuesta.EncuestaId))
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
        return View(encuesta);
    }

    // GET: Encuestas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var encuesta = await _context.Encuestas
            .FirstOrDefaultAsync(m => m.EncuestaId == id);
        if (encuesta == null)
        {
            return NotFound();
        }

        return View(encuesta);
    }

    // POST: Encuestas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var encuesta = await _context.Encuestas.FindAsync(id);
        if (encuesta != null)
        {
            _context.Encuestas.Remove(encuesta);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EncuestaExists(int id)
    {
        return _context.Encuestas.Any(e => e.EncuestaId == id);
    }
}
