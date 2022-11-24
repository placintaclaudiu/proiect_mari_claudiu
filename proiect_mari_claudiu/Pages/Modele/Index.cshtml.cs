using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Data;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Pages.Modele
{
    public class IndexModel : PageModel
    {
        private readonly proiect_mari_claudiu.Data.proiect_mari_claudiuContext _context;

        public IndexModel(proiect_mari_claudiu.Data.proiect_mari_claudiuContext context)
        {
            _context = context;
        }

        public IList<Model> Model { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Model != null)
            {
                Model = await _context.Model.ToListAsync();
            }
        }
    }
}
