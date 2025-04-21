namespace SinemaApp.API.DTO
{
    public class Seans_DTO
    {
        public int Id { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public int SalonId { get; set; }
    }

}