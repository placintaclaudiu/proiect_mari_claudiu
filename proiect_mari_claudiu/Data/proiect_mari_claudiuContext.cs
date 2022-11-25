using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect_mari_claudiu.Models;

namespace proiect_mari_claudiu.Data
{
    public class proiect_mari_claudiuContext : DbContext
    {
        public proiect_mari_claudiuContext (DbContextOptions<proiect_mari_claudiuContext> options)
            : base(options)
        {
        }

        public DbSet<proiect_mari_claudiu.Models.Masina> Masina { get; set; } = default!;

        public DbSet<proiect_mari_claudiu.Models.Furnizor> Furnizor { get; set; }

        public DbSet<proiect_mari_claudiu.Models.Model> Model { get; set; }

        public DbSet<proiect_mari_claudiu.Models.Tip> Tip { get; set; }

        public DbSet<proiect_mari_claudiu.Models.Client> Client { get; set; }

        public DbSet<proiect_mari_claudiu.Models.Inchiriere> Inchiriere { get; set; }
    }
}
