﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Furnizori
{
    public class EditModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public EditModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Furnizor Furnizor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Furnizor == null)
            {
                return NotFound();
            }

            var furnizor =  await _context.Furnizor.FirstOrDefaultAsync(m => m.ID == id);
            if (furnizor == null)
            {
                return NotFound();
            }
            Furnizor = furnizor;
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

            _context.Attach(Furnizor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnizorExists(Furnizor.ID))
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

        private bool FurnizorExists(int id)
        {
          return _context.Furnizor.Any(e => e.ID == id);
        }
    }
}
