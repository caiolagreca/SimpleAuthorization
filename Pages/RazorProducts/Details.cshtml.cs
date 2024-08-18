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
    public class DetailsModel : PageModel
    {
        private readonly BasicAuthorization.Data.ApplicationDbContext _context;

        public DetailsModel(BasicAuthorization.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Products Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
