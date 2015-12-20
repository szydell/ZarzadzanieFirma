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
        ulong pesel;
        public string imie; //""
        public string nazwisko;
        DateTime dataUrodzenia;
        public UmowaTyp umowa = UmowaTyp.Zlecenie;
        public Wynagrodzenie wynagrodzenie; //null
        public Operacja[] operacje = new Operacja[20]; //Zamienić na kolekcję

        //akcesory
        public ulong pobierzPesel() //get
        {
            return pesel;
        }
        public void ustawPesel(ulong pesel) //set
        {
            if (pesel > 10000000000 && pesel < 100000000000)
            {
                this.pesel = pesel;
            }
            else
            {
                throw new PracownikException()
                {
                    danePracownik = this.imie + " " + this.nazwisko,
                    komunikat = "PESEL musi miec 11 znakow"
                };
            }
        }
    }

    public enum UmowaTyp
    {
        OPrace, Dzieło, Zlecenie, Kontrakt //
    }
}