using Microsoft.AspNetCore.Identity;

namespace Inambu_Manufacturing_Pty.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
  public string DisplayName  { get; set; } = string.Empty;
  public StaffLevel StaffLevel { get; set; } = StaffLevel.User;
}

