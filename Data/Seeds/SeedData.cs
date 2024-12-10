using Microsoft.AspNetCore.Identity;

namespace Web.Data.Seeds;

public class SeedData
{
    public static async Task InitializeRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = ["Líder Social", "Junta de Acción Comunal", "Delegado Alcaldía"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

}
