using AspNetHw13.Helpers;
using AspNetHw13.Models;
using AspNetHw13.Models.ViewModels;
using AspNetHw13.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetHw13.Controllers
{
    public class UsersController(UserRepository repository) : Controller
    {
        public async Task<IActionResult> Index([FromQuery] PaginationParameters parameters)
        {
            PaginatedList<ApplicationUser> userList = await repository.GetPageAsync(parameters);
            PaginatedList<UserViewModel> userViewModelList = userList.Select(user => new UserViewModel(user.UserName, user.Email));
            return View(new UserIndexViewModel(userViewModelList, parameters));
        }
    }
}
