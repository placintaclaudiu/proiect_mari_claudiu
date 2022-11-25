using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Masini
{
    [Authorize(Roles = "Admin")]

    public class EditModel : MasinaTipPageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public EditModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) //|| _context.Masina == null)
            {
                return NotFound();
            }

            var masina =  await _context.Masina.FirstOrDefaultAsync(m => m.ID == id);
            
            
            if (masina == null)
            {              
                return NotFound();
            }
            Masina = masina;
             Masina = await _context.Masina
                .Include(b => b.Furnizor)
                .Include(b => b.TipMasini).ThenInclude(b => b.Tip)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            PopulateAssignedTipData(_context, Masina);

            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            ViewData["ModelID"] = new SelectList(_context.Set<Model>(), "ID", "NumeModel");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var masinaToUpdate = await _context.Masina
            .Include(i => i.Furnizor)
            .Include(i => i.TipMasini)
            .ThenInclude(i => i.Tip)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (masinaToUpdate == null)
            {
                return NotFound();
            }
            
            if (await TryUpdateModelAsync<Masina>(
            masinaToUpdate,
            "Masina",
            i => i.Denumire, i => i.Furnizor,
            i => i.Pret, i => i.An_Fabricatie, i => i.FurnizorID))
            {
                UpdateMasinaCategories(_context, selectedCategories, masinaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateMasinaCategories(_context, selectedCategories, masinaToUpdate);
            PopulateAssignedTipData(_context, masinaToUpdate);
            return Page();
        }
    }

}

