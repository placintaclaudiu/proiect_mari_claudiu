
namespace proiect_mari_claudiu.Models.ViewModels
{
    public class TipIndexData
    {
        public IEnumerable<Tip> Tipuri { get; set; }
        public IEnumerable<TipMasina> TipMasini { get; set; }
        public IEnumerable<Masina> Masini { get; set; }
    }
}
