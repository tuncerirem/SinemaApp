using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Bilet
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int SeansId { get; set; }
        public int KoltukId { get; set; }
        public decimal Fiyat { get; set; }
        public string Qr { get; set; }
        public int FilmId { get; set; }
    }
}
