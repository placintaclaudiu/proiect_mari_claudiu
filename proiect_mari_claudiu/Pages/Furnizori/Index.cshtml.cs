using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;
using proiect_mari_claudiu.Models.ViewModels;

namespace proiect_mari_claudiu.Pages.Furnizori
{
    public class IndexModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public IndexModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        public IList<Furnizor> Furnizor { get; set; } = default!;

        public FurnizorIndexData FurnizorData { get; set; }
        public int FurnizorID { get; set; }
        public int MasinaID { get; set; }

        public async Task OnGetAsync(int? id, int? masinaID)
        {
            FurnizorData = new FurnizorIndexData();
            FurnizorData.Furnizori = await _context.Furnizor
            .Include(i => i.Masini)
          //  .ThenInclude(c => c.Model)
            .OrderBy(i => i.NumeFurnizor)
            .ToListAsync();
            if (id != null)
            {
                FurnizorID = id.Value;
                Furnizor furnizor = FurnizorData.Furnizori
                .Where(i => i.ID == id.Value).Single();
                FurnizorData.Masini = furnizor.Masini;
            }

            /* public async Task OnGetAsync()
             {
                 if (_context.Furnizor != null)
                 {
                     Furnizor = await _context.Furnizor.ToListAsync();
                 }
             }
            */
        }
    }
}
