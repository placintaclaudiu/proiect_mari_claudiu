namespace proiect_mari_claudiu.Models
{
    public class MasinaData
    {
        public IEnumerable<Masina> Masini { get; set; }
        public IEnumerable<Tip> Tipuri{ get; set; }
        public IEnumerable<TipMasina> TipMasini { get; set; }
    }
}
