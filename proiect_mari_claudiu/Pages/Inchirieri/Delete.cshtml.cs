using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Inchirieri
{
    public class DeleteModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public DeleteModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inchiriere Inchiriere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }

            var inchiriere = await _context.Inchiriere.Include(b => b.Client).Include(b => b.Masina).FirstOrDefaultAsync(m => m.ID == id);

            if (inchiriere == null)
            {
                return NotFound();
            }
            else 
            {
                Inchiriere = inchiriere;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }
            var inchiriere = await _context.Inchiriere.FindAsync(id);

            if (inchiriere != null)
            {
                Inchiriere = inchiriere;
                _context.Inchiriere.Remove(Inchiriere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
