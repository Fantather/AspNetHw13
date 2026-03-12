using AspNetHw13.Data;
using AspNetHw13.Helpers;
using AspNetHw13.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetHw13.Repositories
{
    public class UserRepository(UserManager<ApplicationUser> userManager)
    {
        public async Task<PaginatedList<ApplicationUser>> GetPageAsync(PaginationParameters parameters)
        {
            return await PaginatedList<ApplicationUser>.CreateAsync(userManager.Users, parameters);
        }
    }
}
