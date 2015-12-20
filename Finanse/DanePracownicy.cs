using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy.Finanse
{
    public class Osoba
    {

    }

    public class Pracownik
    {
        //pola statyczne
        static float dodatekWakacyjny = 1000f;

        //pola obiektowe
        public uint ID; //0
        public ulong pesel;
        public string imie; //""
        public string nazwisko;
        DateTime dataUrodzenia;
        public UmowaTyp umowa = UmowaTyp.Zlecenie;
        public Wynagrodzenie wynagrodzenie; //null
        public Operacja[] operacje = new Operacja[20]; //Zamienić na kolekcję

    }

    public enum UmowaTyp
    {
        OPrace, Dzieło, Zlecenie, Kontrakt //
    }
}