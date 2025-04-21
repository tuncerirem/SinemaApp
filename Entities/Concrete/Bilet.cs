using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Bilet
    {
        public int Id { get; set; }
        
        public decimal Fiyat { get; set; }
        public string Qr { get; set; }
        public int FilmId { get; set; }


        public int KullaniciId { get; set; }
        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanici { get; set; }
        public int SeansId { get; set; }
        public int KoltukId { get; set; }

       
        //public int SalonId { get; set; }
        //[ForeignKey("SalonId")]
        //public virtual Salon Salon{ get; set; }

        [ForeignKey("SeansId")]
        public virtual Seans Seans { get; set; }

        [ForeignKey("KoltukId")]
        public virtual Koltuk Koltuk { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film Film { get; set; }

    }
}
