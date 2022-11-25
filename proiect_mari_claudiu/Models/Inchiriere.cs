using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace proiect_mari_claudiu.Models
{
    public class Inchiriere
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? MasinaID { get; set; }
        public Masina? Masina { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data preluare")]
        public DateTime DataPreluare { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data returnare")]
        public DateTime DataReturnare { get; set; }
    }
}
