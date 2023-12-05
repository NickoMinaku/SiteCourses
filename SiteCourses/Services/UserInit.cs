using Microsoft.AspNetCore.Identity;
using SiteCourses.Models;
using Microsoft.IdentityModel.Tokens;
public class UserInit
{
    public async Task InitAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, string userName, string email, string password, string? role=null)
    {
        if (!role.IsNullOrEmpty() && await roleManager.FindByNameAsync(role) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
        var us = await roleManager.FindByNameAsync(role);
        if (!role.IsNullOrEmpty() && await userManager.FindByEmailAsync(email) == null)
        {
            User user = new User{ UserName = userName, Email = email };
            IdentityResult idresult = await userManager.CreateAsync(user, password);
            if (idresult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}