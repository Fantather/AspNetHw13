using AspNetHw13.Data;
using AspNetHw13.Helpers;
using AspNetHw13.Models;
using AspNetHw13.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AspNetHw13.Repositories
{
    public class UserRepository(UserManager<ApplicationUser> userManager)
    {
        public async Task<PaginatedList<ApplicationUser>> GetPageAsync(PaginationParameters parameters)
        {
            var queryable = userManager.Users;
            if(!string.IsNullOrWhiteSpace(parameters.Query))
            {
                queryable = queryable.Where(user => user.UserName.Contains(parameters.Query));
            }

            return await PaginatedList<ApplicationUser>
                    .CreateAsync(queryable, parameters);
        }
    }
}
