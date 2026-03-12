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
            UserIndexViewModel viewModel = new(await repository.GetPageAsync(parameters), parameters);
            return View(viewModel);
        }
    }
}
