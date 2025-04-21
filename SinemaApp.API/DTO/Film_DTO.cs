namespace SinemaApp.API.DTO
{
    public class Film_DTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Zaman { get; set; }
        public string Fotograf { get; set; }
        public string Fragman { get; set; }
        public List<Seans_DTO> Seanslar { get; set; }
    }
}
