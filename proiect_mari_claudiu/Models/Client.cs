using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace proiect_mari_claudiu.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula!!!")]

        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula!!!")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }

        
        [StringLength(70)]
        public string? Adresa { get; set; }


        public string Email { get; set; }

        [RegularExpression(@"^([0]{1})[-. ]?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
           ErrorMessage = "Telefonul trebuie sa inceapa cu cifra 0!")]
        public string? Telefon { get; set; }

        [Display(Name = "Nume complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Inchiriere>? Inchirieri { get; set; }
    }
}
