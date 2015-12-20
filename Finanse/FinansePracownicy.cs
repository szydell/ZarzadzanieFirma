using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy.Finanse
{
    public class Operacja
    {        
        DateTime data;
        public float kwota;
        public string tytul;
        public bool wykonanie; //= false;
    }

    public struct Wynagrodzenie
    {
        public float pensjaPodstawowa;
        public string waluta;
        public float premia;
    }
}