using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace proiect_mari_claudiu.Models
{
    public class Furnizor
    {
        public int ID { get; set; }
       
        [Display(Name = "Numele furnizorului")]
        public string NumeFurnizor { get; set; }
        public ICollection<Masina>? Masini { get; set; }    
    }
}
