using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect_mari_claudiu.Models
{
    public class Masina
    {
        public int ID { get; set; }
        
        [Display(Name = "Denumirea masinii")]
        public string Denumire { get; set; }

        [Column(TypeName ="decimal(8,2)")]
        [Display(Name = "Pret (€)")]
        public decimal Pret { get; set; }

        [Display(Name = "Anul fabricatiei")]
        public DateTime An_Fabricatie {get; set; }

        public int? FurnizorID { get; set; }
        public Furnizor? Furnizor { get; set; }

        public int? ModelID { get; set; }
        public Model? Model { get; set; }

        public ICollection<TipMasina>? TipMasini { get; set; }  

    }
}
