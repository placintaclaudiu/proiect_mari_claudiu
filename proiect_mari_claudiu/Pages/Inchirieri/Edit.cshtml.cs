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
    public class EditModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public EditModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }

            var inchiriere =  await _context.Inchiriere.FirstOrDefaultAsync(m => m.ID == id);
            if (inchiriere == null)
            {
                return NotFound();
            }
            Inchiriere = inchiriere;


            var masinaList = _context.Masina
                     .Include(b => b.Model)
                     .Select(x => new
                     {
                         x.ID,
                         MasinaFullName = x.Denumire + " - " + x.Model.NumeModel
                     });
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            ViewData["MasinaID"] = new SelectList(masinaList, "ID", "MasinaFullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inchiriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InchiriereExists(Inchiriere.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InchiriereExists(int id)
        {
          return _context.Inchiriere.Any(e => e.ID == id);
        }
    }
}
