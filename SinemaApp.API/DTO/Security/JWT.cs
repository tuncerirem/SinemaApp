namespace SinemaApp.API.Security
{
    public class JWT
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; } //Bitiş Süresi
    }
}
