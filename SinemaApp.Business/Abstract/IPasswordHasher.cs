using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaApp.Entities.Concrete;
using SinemaApp.Business.Abstract;


namespace SinemaApp.Business.Abstract
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string inputPassword);
    }
}
