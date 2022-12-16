using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Inchirieri
{
    public class CreateModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public CreateModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var masinaList = _context.Masina
               .Include(b => b.Model)
               .Select(x => new
               {
                   x.ID,
                   MasinaFullName = x.Denumire + " - " + x.Model.NumeModel
               });
            ViewData["MasinaID"] = new SelectList(masinaList, "ID", "MasinaFullName");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
        
            return Page();
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inchiriere.Add(Inchiriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
