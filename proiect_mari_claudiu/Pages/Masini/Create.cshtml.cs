using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Masini
{
    public class CreateModel : MasinaTipPageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public CreateModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FurnizorID"] = new SelectList(_context.Set<Furnizor>(), "ID", "NumeFurnizor");
            ViewData["ModelID"] = new SelectList(_context.Set<Model>(), "ID", "NumeModel");

            var masina = new Masina();
            masina.TipMasini = new List<TipMasina>();
            PopulateAssignedTipData(_context, masina);

            return Page();
        }

        [BindProperty]
        public Masina Masina { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newMasina = Masina;
            if (selectedCategories != null)
            {
                newMasina.TipMasini = new List<TipMasina>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new TipMasina
                    {
                        TipID = int.Parse(cat)
                    };
                    newMasina.TipMasini.Add(catToAdd);
                }
            }
            //Masina.TipMasini = newMasina.TipMasini;

            _context.Masina.Add(newMasina);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedTipData(_context, newMasina);
            return Page();
        }


    }
}



