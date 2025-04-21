using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        //public Salon Salon { get; set; }

        //public int BiletId { get; set; }

        //public Bilet Bilet { get; set; }

        [ForeignKey("SalonId")]
        public virtual Salon Salon { get; set; }

        // Bilet ile bire bir ilişki
        public virtual Bilet Bilet { get; set; }

    }
}
