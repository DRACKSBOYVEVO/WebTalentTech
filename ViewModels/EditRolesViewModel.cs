namespace Web.ViewModels;

public class EditRolesViewModel
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public List<RoleSelectionViewModel> Roles { get; set; }
}
