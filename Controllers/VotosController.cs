using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuVozLocal.DataAccess.Context;
using TuVozLocal.DataAccess.Entities;

namespace Web.Controllers;

public class VotosController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: Votoes
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Votos.Include(v => v.Encuesta).Include(v => v.LiderSocial).Include(v => v.ProyectoSocial);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Votoes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var voto = await _context.Votos
            .Include(v => v.Encuesta)
            .Include(v => v.LiderSocial)
            .Include(v => v.ProyectoSocial)
            .FirstOrDefaultAsync(m => m.VotoId == id);
        if (voto == null)
        {
            return NotFound();
        }

        return View(voto);
    }

    // GET: Votoes/Create
    public IActionResult Create()
    {
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Apellidos");
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre");
        ViewData["ProyectoSocialId"] = new SelectList(_context.ProyectoSociales, "ProyectoSocialId", "LiderSocialId");
        return View();
    }

    // POST: Votoes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("VotoId,EncuestaId,LiderSocialId,FechaVoto,Cedula,ProyectoSocialId")] Voto voto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(voto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Apellidos", voto.EncuestaId);
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", voto.LiderSocialId);
        ViewData["ProyectoSocialId"] = new SelectList(_context.ProyectoSociales, "ProyectoSocialId", "LiderSocialId", voto.ProyectoSocialId);
        return View(voto);
    }

    // GET: Votoes/Edit/5
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
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Apellidos", voto.EncuestaId);
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", voto.LiderSocialId);
        ViewData["ProyectoSocialId"] = new SelectList(_context.ProyectoSociales, "ProyectoSocialId", "LiderSocialId", voto.ProyectoSocialId);
        return View(voto);
    }

    // POST: Votoes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("VotoId,EncuestaId,LiderSocialId,FechaVoto,Cedula,ProyectoSocialId")] Voto voto)
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
        ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "Apellidos", voto.EncuestaId);
        ViewData["LiderSocialId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", voto.LiderSocialId);
        ViewData["ProyectoSocialId"] = new SelectList(_context.ProyectoSociales, "ProyectoSocialId", "LiderSocialId", voto.ProyectoSocialId);
        return View(voto);
    }

    // GET: Votoes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var voto = await _context.Votos
            .Include(v => v.Encuesta)
            .Include(v => v.LiderSocial)
            .Include(v => v.ProyectoSocial)
            .FirstOrDefaultAsync(m => m.VotoId == id);
        if (voto == null)
        {
            return NotFound();
        }

        return View(voto);
    }

    // POST: Votoes/Delete/5
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
