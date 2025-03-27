using System;
using System.Collections.Generic;
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
        public Salon Salon { get; set; }  
        public Film Film { get; set; }  
        public ICollection<Bilet> Biletler { get; set; }
    }
}
