using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace proiect_mari_claudiu.Models
{
    public class Model
    {
        public int ID { get; set; }

        [Display(Name = "Numele modelului")]
        public string NumeModel { get; set; }

        [Display(Name = "Descriere")]
        public string Descriere { get; set; }
        public ICollection<Masina>? Masini { get; set; }
    }
}
