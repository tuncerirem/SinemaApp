namespace SinemaApp.API.DTO
{
    public class Salon_DTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Seans_DTO> Seanslar { get; set; }
    }
}
