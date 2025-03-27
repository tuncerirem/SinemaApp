using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Film
    {
        public int Id { get; set; }
        public string Tur { get; set; }
        public string Ad { get; set; }
        public int Zaman { get; set; }
        public string Fragman { get; set; }
        public string Fotograf { get; set; }
        public ICollection<Seans> Seanslar { get; set; }
        public ICollection<Bilet> Biletler { get; set; }    


    }


}
