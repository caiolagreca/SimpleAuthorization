using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasicAuthorization.Data;

namespace BasicAuthorization.Pages.RazorProducts
{
    public class IndexModel : PageModel
    {
        private readonly BasicAuthorization.Data.ApplicationDbContext _context;

        public IndexModel(BasicAuthorization.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Products> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
