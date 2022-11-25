using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Masini
{
    public class IndexModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public IndexModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        public IList<Masina> Masina { get;set; } = default!;
        public MasinaData MasinaD { get; set; }
        public int MasinaID { get; set; }

        public int TipID { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? tipID, string searchString)
        {
            MasinaD = new MasinaData();

            CurrentFilter = searchString;

            MasinaD.Masini = await _context.Masina
            .Include(b => b.Furnizor)
            .Include(b=>b.Model)
            .Include(b => b.TipMasini)
            .ThenInclude(b => b.Tip)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                MasinaD.Masini = MasinaD.Masini.Where(s => s.Denumire.Contains(searchString));
            }

            if (id != null)
            {
                MasinaID = id.Value;
                Masina masina = MasinaD.Masini
                .Where(i => i.ID == id.Value).Single();
                MasinaD.Tipuri = masina.TipMasini.Select(s => s.Tip);
            }
        }

    }
}
