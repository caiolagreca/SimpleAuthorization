using BasicAuthorization.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BasicAuthorization.Areas.Identity.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        //public ApplicationDbContext _DbCtx { get; set; }

        public IEnumerable<IdentityUser> Users { get; set; }
                        = Enumerable.Empty<IdentityUser>();

        public UsersModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
        }
    }
}
