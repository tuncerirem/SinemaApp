﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaApp.Entities.Concrete
{
    public class Rol
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public ICollection<Kullanici> Kullanicilar { get; set; }
    }
}
