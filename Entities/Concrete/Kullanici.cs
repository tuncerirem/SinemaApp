using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; } 
        public string Soyad { get; set; }    
        public string Email { get; set; } 
        public string Sifre { get; set; } 
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public bool IsDeleted { get; set; } = false;
        
        public ICollection<Bilet> Biletler { get; set; }

    }
}
