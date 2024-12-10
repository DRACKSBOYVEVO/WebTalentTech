using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

[Authorize(Roles = "Líder Social")]
public class ProyectoSocialController(ApplicationDbContext context, UserManager<IdentityUser> userManager) : Controller
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly ApplicationDbContext _context = context;

    // GET: ProyectoSocial
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.ProyectoSociales.Include(p => p.LiderSocial).Include(p => p.Persona);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: ProyectoSocial/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proyectoSocial = await _context.ProyectoSociales
            .Include(p => p.LiderSocial)
            .Include(p => p.Persona)
            .FirstOrDefaultAsync(m => m.ProyectoSocialId == id);
        if (proyectoSocial == null)
        {
            return NotFound();
        }

        return View(proyectoSocial);
    }

    // GET: ProyectoSocial/Create
    public IActionResult Create()
    {
        ViewData["LiderSocialId"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["PersonaId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre");
        return View();
    }

    // POST: ProyectoSocial/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProyectoSocialId,Titulo,Descripcion,Archivo,FechaCreacion,LiderSocialId,PersonaId")] ProyectoSocial proyectoSocial)
    {
        var user = await _userManager.GetUserAsync(User);
        var isLiderSocial = await _userManager.IsInRoleAsync(user, "Líder Social");

        if (!isLiderSocial)
        {
            return Forbid();
        }

        if (ModelState.IsValid)
        {
            _context.Add(proyectoSocial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["LiderSocialId"] = new SelectList(_context.Users, "Id", "Id", proyectoSocial.LiderSocialId);
        ViewData["PersonaId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", proyectoSocial.PersonaId);
        return View(proyectoSocial);
    }

    // GET: ProyectoSocial/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proyectoSocial = await _context.ProyectoSociales.FindAsync(id);
        if (proyectoSocial == null)
        {
            return NotFound();
        }
        ViewData["LiderSocialId"] = new SelectList(_context.Users, "Id", "Id", proyectoSocial.LiderSocialId);
        ViewData["PersonaId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", proyectoSocial.PersonaId);
        return View(proyectoSocial);
    }

    // POST: ProyectoSocial/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProyectoSocialId,Titulo,Descripcion,Archivo,FechaCreacion,LiderSocialId,PersonaId")] ProyectoSocial proyectoSocial)
    {
        if (id != proyectoSocial.ProyectoSocialId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(proyectoSocial);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoSocialExists(proyectoSocial.ProyectoSocialId))
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
        ViewData["LiderSocialId"] = new SelectList(_context.Users, "Id", "Id", proyectoSocial.LiderSocialId);
        ViewData["PersonaId"] = new SelectList(_context.LiderSocials, "LiderSocialId", "Nombre", proyectoSocial.PersonaId);
        return View(proyectoSocial);
    }

    // GET: ProyectoSocial/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proyectoSocial = await _context.ProyectoSociales
            .Include(p => p.LiderSocial)
            .Include(p => p.Persona)
            .FirstOrDefaultAsync(m => m.ProyectoSocialId == id);
        if (proyectoSocial == null)
        {
            return NotFound();
        }

        return View(proyectoSocial);
    }

    // POST: ProyectoSocial/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var proyectoSocial = await _context.ProyectoSociales.FindAsync(id);
        if (proyectoSocial != null)
        {
            _context.ProyectoSociales.Remove(proyectoSocial);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProyectoSocialExists(int id)
    {
        return _context.ProyectoSociales.Any(e => e.ProyectoSocialId == id);
    }
}
