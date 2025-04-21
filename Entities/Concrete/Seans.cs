using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Seans
    {
        public int Id { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public int SalonId { get; set; }
        public int FilmId { get; set; }

        [ForeignKey("SalonId")]
        public virtual Salon Salon { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film Film { get; set; }  
        public ICollection<Bilet> Biletler { get; set; }
    }
}
