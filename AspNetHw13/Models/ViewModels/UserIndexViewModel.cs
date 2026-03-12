using AspNetHw13.Helpers;

namespace AspNetHw13.Models.ViewModels
{
    public record class UserIndexViewModel(PaginatedList<UserViewModel> Users, PaginationParameters Parameters);
}
