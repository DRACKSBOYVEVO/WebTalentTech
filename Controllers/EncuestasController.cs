﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuVozLocal.DataAccess.Context;
using TuVozLocal.DataAccess.Entities;

namespace Web.Controllers;

public class EncuestasController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: Encuestas
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Encuestas
                                                    .Include(e => e.EnfoqueDiferencial)
                                                    .Include(e => e.RangoEdad)
                                                    .Include(e => e.Sector)
                                                    .Include(e => e.Sexo)
                                                    .Include(e => e.TipoIdentificacion)
                                                    .Include(e => e.UbicacionProyecto);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Encuestas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var encuesta = await _context.Encuestas
            .Include(e => e.EnfoqueDiferencial)
            .Include(e => e.RangoEdad)
            .Include(e => e.Sector)
            .Include(e => e.Sexo)
            .Include(e => e.TipoIdentificacion)
            .Include(e => e.UbicacionProyecto)
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
        ViewData["EnfoqueDiferencialId"] = new SelectList(_context.EnfoquesDiferenciales, "Nombre", "Nombre");
        ViewData["RangoEdadId"] = new SelectList(_context.RangosEdad, "Descripcion", "Descripcion");
        ViewData["SectorId"] = new SelectList(_context.Sectores, "Nombre", "Nombre");
        ViewData["SexoId"] = new SelectList(_context.Sexos, "Nombre", "Nombre");
        ViewData["TipoIdentificacionId"] = new SelectList(_context.TiposIdentificacion, "Nombre", "Nombre");
        ViewData["UbicacionProyectoId"] = new SelectList(_context.UbicacionesProyecto, "Nombre", "Nombre");
        return View();
    }

    // POST: Encuestas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EncuestaId,Descripcion,FechaCreacion,Nombres,Apellidos,TipoIdentificacionId,NumeroIdentificacion,Ocupacion,SexoId,RangoEdadId,EnfoqueDiferencialId,CorreoElectronico,NumeroTelefonico,FormulacionPorOrganizacion,SectorId,UbicacionProyectoId")] Encuesta encuesta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(encuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["EnfoqueDiferencialId"] = new SelectList(_context.EnfoquesDiferenciales, "Nombre", "Nombre", encuesta.EnfoqueDiferencialId);
        ViewData["RangoEdadId"] = new SelectList(_context.RangosEdad, "Descripcion", "Descripcion", encuesta.RangoEdadId);
        ViewData["SectorId"] = new SelectList(_context.Sectores, "Nombre", "Nombre", encuesta.SectorId);
        ViewData["SexoId"] = new SelectList(_context.Sexos, "Nombre", "Nombre", encuesta.SexoId);
        ViewData["TipoIdentificacionId"] = new SelectList(_context.TiposIdentificacion, "Nombre", "Nombre", encuesta.TipoIdentificacionId);
        ViewData["UbicacionProyectoId"] = new SelectList(_context.UbicacionesProyecto, "Nombre", "Nombre", encuesta.UbicacionProyectoId);
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
        ViewData["EnfoqueDiferencialId"] = new SelectList(_context.EnfoquesDiferenciales, "Nombre", "Nombre", encuesta.EnfoqueDiferencialId);
        ViewData["RangoEdadId"] = new SelectList(_context.RangosEdad, "Descripcion", "Descripcion", encuesta.RangoEdadId);
        ViewData["SectorId"] = new SelectList(_context.Sectores, "Nombre", "Nombre", encuesta.SectorId);
        ViewData["SexoId"] = new SelectList(_context.Sexos, "Nombre", "Nombre", encuesta.SexoId);
        ViewData["TipoIdentificacionId"] = new SelectList(_context.TiposIdentificacion, "Nombre", "Nombre", encuesta.TipoIdentificacionId);
        ViewData["UbicacionProyectoId"] = new SelectList(_context.UbicacionesProyecto, "Nombre", "Nombre", encuesta.UbicacionProyectoId);
        return View(encuesta);
    }

    // POST: Encuestas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EncuestaId,Descripcion,FechaCreacion,Nombres,Apellidos,TipoIdentificacionId,NumeroIdentificacion,Ocupacion,SexoId,RangoEdadId,EnfoqueDiferencialId,CorreoElectronico,NumeroTelefonico,FormulacionPorOrganizacion,SectorId,UbicacionProyectoId")] Encuesta encuesta)
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
        ViewData["EnfoqueDiferencialId"] = new SelectList(_context.EnfoquesDiferenciales, "Nombre", "Nombre", encuesta.EnfoqueDiferencialId);
        ViewData["RangoEdadId"] = new SelectList(_context.RangosEdad, "Descripcion", "Descripcion", encuesta.RangoEdadId);
        ViewData["SectorId"] = new SelectList(_context.Sectores, "Nombre", "Nombre", encuesta.SectorId);
        ViewData["SexoId"] = new SelectList(_context.Sexos, "Nombre", "Nombre", encuesta.SexoId);
        ViewData["TipoIdentificacionId"] = new SelectList(_context.TiposIdentificacion, "Nombre", "Nombre", encuesta.TipoIdentificacionId);
        ViewData["UbicacionProyectoId"] = new SelectList(_context.UbicacionesProyecto, "Nombre", "Nombre", encuesta.UbicacionProyectoId);
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
            .Include(e => e.EnfoqueDiferencial)
            .Include(e => e.RangoEdad)
            .Include(e => e.Sector)
            .Include(e => e.Sexo)
            .Include(e => e.TipoIdentificacion)
            .Include(e => e.UbicacionProyecto)
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
