using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class VotarController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    /// <summary>
    /// Obtener todos los votos de la base de datos
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        var contarVotos = _context.Votos.Include(v => v.Encuesta)
                                        .Include(v => v.LiderSocial);

        return View(await contarVotos.ToListAsync());
    }

    // GET: Votar/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var voto = await _context.Votos
            .Include(v => v.Encuesta)
            .Include(v => v.LiderSocial)
            .FirstOrDefaultAsync(m => m.VotoId == id);
        if (voto == null)
        {
            return NotFound();
        }

        return View(voto);
    }

    // GET: Votar/Create
    public IActionResult Create()
    {
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Descripcion");
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre");
        return View();
    }

    /// <summary>
    /// POST: Crear un voto en la base de datos
    /// </summary>
    /// <param name="voto"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("VotoId,EncuestaId,LiderSocialId,FechaVoto")] Voto voto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(voto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Descripcion", voto.EncuestaId);
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", voto.LiderSocialId);
        return View(voto);
    }

    /// <summary>
    /// GET: Edita un voto con Id x de la base de datos
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var voto = await _context.Votos.FindAsync(id);
        if (voto == null)
        {
            return NotFound();
        }
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Descripcion", voto.EncuestaId);
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", voto.LiderSocialId);
        return View(voto);
    }

    // POST: Votar/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VotoId,EncuestaId,LiderSocialId,FechaVoto")] Voto voto)
    {
        if (id != voto.VotoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(voto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotoExists(voto.VotoId))
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
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Descripcion", voto.EncuestaId);
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", voto.LiderSocialId);
        return View(voto);
    }

    // GET: Votar/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var voto = await _context.Votos
            .Include(v => v.Encuesta)
            .Include(v => v.LiderSocial)
            .FirstOrDefaultAsync(m => m.VotoId == id);
        if (voto == null)
        {
            return NotFound();
        }

        return View(voto);
    }

    // POST: Votar/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var voto = await _context.Votos.FindAsync(id);
        if (voto != null)
        {
            _context.Votos.Remove(voto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool VotoExists(int id)
    {
        return _context.Votos.Any(e => e.VotoId == id);
    }
}
