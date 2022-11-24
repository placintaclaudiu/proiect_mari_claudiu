using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace proiect_mari_claudiu.Models
{
    public class Tip
    {
        public int ID { get; set; }
        [Display(Name = "Tipul Masinii")]
        public string NumeTip { get; set; } 
        public ICollection<TipMasina>? TipMasini { get; set; }

    }
}
