namespace Web.ViewModels;

public class UserWithRolesViewModel
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public IEnumerable<string> Roles { get; set; }
}
