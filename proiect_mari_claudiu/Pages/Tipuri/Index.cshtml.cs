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

namespace proiect_mari_claudiu.Pages.Tipuri
{
    public class IndexModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public IndexModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        public IList<Tip> Tip { get; set; } = default!;

        public TipIndexData TipData { get; set; }
        public int TipID { get; set; }
        public int MasinaID { get; set; }

        public async Task OnGetAsync(int? id, int? masinaID)
        {
            TipData = new TipIndexData();
            TipData.Tipuri = await _context.Tip
            .Include(i => i.TipMasini)
            .ThenInclude(c => c.Masina)
            .OrderBy(i => i.NumeTip)
            .ToListAsync();
            if (id != null)
            {
                TipID = id.Value;
                Tip tip = TipData.Tipuri
                .Where(i => i.ID == id.Value).Single();
                TipData.TipMasini = tip.TipMasini;
            }


            /*  
              public async Task OnGetAsync()
              {
                  if (_context.Tip != null)
                  {
                      Tip = await _context.Tip.ToListAsync();
                  }
              }
            */



        }
    }
}
