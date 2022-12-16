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
    public class IndexModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public IndexModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        public IList<Inchiriere> Inchiriere { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inchiriere != null)
            {
                Inchiriere = await _context.Inchiriere
                .Include(i => i.Masina)
                .ThenInclude(b => b.Model)
                .Include(i => i.Client).ToListAsync();
                //.Select(x => new
                //   {
                // x.ID,
                //  MasinaFullName = x.Masina.Denumire + " - " + x.Masina.Model.NumeModel
                // })

            }
        }
    }
}
