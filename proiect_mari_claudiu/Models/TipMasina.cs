namespace proiect_mari_claudiu.Models
{
    public class TipMasina
    {
        public int ID { get; set; }
        public int MasinaID { get; set; }
        public Masina Masina { get; set;}
        public int TipID { get; set; }
        public Tip Tip { get; set; }
    }
}
