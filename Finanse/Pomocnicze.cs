using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pracownicy.Finanse
{
    public class PracownikException : Exception
    {
        public string danePracownik;
        public string komunikat;
    }
}
