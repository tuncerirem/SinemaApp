using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Salon
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Kapasite { get; set; }
        public ICollection<Koltuk> Koltuklar { get; set; }
        public ICollection<Seans> Seanslar { get; set; }
    }
}
