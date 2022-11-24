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

namespace proiect_mari_claudiu.Pages.Modele
{
    public class EditModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public EditModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model Model { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Model == null)
            {
                return NotFound();
            }

            var model =  await _context.Model.FirstOrDefaultAsync(m => m.ID == id);
            if (model == null)
            {
                return NotFound();
            }
            Model = model;
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

            _context.Attach(Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(Model.ID))
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

        private bool ModelExists(int id)
        {
          return _context.Model.Any(e => e.ID == id);
        }
    }
}
