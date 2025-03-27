using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Koltuk
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string Durum { get; set; }
        public Salon Salon { get; set; }

    }
}
