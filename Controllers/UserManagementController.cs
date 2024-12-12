using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuVozLocal.DataAccess.ViewModels;

namespace Web.Controllers;

[Authorize(Roles = "Administrador")]
public class UserManagementController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : Controller
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    /// <summary>
    /// Action para listar usuarios
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var userRoles = new List<UserWithRolesViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userRoles.Add(new UserWithRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles
            });
        }

        return View(userRoles);
    }

    /// <summary>
    /// GET: UserManagement/Create
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }

    /// <summary>
    /// POST: UserManagement/Create
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Crear una instancia del rol
            var role = new IdentityRole
            {
                Name = model.RoleName,
                NormalizedName = model.RoleName.ToUpper()
            };

            // Intentar agregar el rol al sistema
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "El rol ha sido creado exitosamente.";
                return RedirectToAction("Index"); // O cualquier otra acción que liste roles
            }

            // Manejo de errores
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // Si algo falla, retornar el modelo a la vista con errores
        return View(model);
    }

    /// <summary>
    /// Acción para actualizar roles de un usuario
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<IActionResult> EditRoles(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        var roles = _roleManager.Roles.ToList();
        var userRoles = await _userManager.GetRolesAsync(user);

        var model = new EditRolesViewModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            Roles = roles.Select(r => new RoleSelectionViewModel
            {
                RoleName = r.Name,
                IsSelected = userRoles.Contains(r.Name)
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditRoles(EditRolesViewModel model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId);
        if (user == null) return NotFound();

        var currentRoles = await _userManager.GetRolesAsync(user);
        var rolesToAdd = model.Roles.Where(r => r.IsSelected && !currentRoles.Contains(r.RoleName)).Select(r => r.RoleName);
        var rolesToRemove = currentRoles.Where(r => !model.Roles.Any(vm => vm.RoleName == r && vm.IsSelected));

        await _userManager.AddToRolesAsync(user, rolesToAdd);
        await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

        return RedirectToAction(nameof(Index));
    }
}
