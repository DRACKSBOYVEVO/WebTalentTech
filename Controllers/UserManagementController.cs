using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers;

public class UserManagementController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : Controller
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    // Action para listar usuarios
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

    // Acción para actualizar roles de un usuario
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
