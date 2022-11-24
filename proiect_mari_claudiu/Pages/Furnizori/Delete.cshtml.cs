using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Furnizori
{
    public class DeleteModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public DeleteModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Furnizor Furnizor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Furnizor == null)
            {
                return NotFound();
            }

            var furnizor = await _context.Furnizor.FirstOrDefaultAsync(m => m.ID == id);

            if (furnizor == null)
            {
                return NotFound();
            }
            else 
            {
                Furnizor = furnizor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Furnizor == null)
            {
                return NotFound();
            }
            var furnizor = await _context.Furnizor.FindAsync(id);

            if (furnizor != null)
            {
                Furnizor = furnizor;
                _context.Furnizor.Remove(Furnizor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
