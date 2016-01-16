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
        #region  pola statyczne
        static float dodatekWakacyjny = 1000f;
        #endregion
        #region pola obiektowe
        public uint ID; //0
        ulong pesel;
        string imie; //""
        string nazwisko;
        DateTime dataUrodzenia;
        public UmowaTyp umowa = UmowaTyp.Zlecenie;
        public Wynagrodzenie wynagrodzenie; //null
        public Operacja[] operacje = new Operacja[20]; //Zamienić na kolekcję
        #endregion
        #region konstruktory
        public Pracownik() //konstruktor domyslny
        {

        }
        public Pracownik(string imie, string nazwisko) //konstruktor z parametrami
        {
            this.Imie = imie;
            this.nazwisko = nazwisko;
        }

        public Pracownik(string imie, string nazwisko, DateTime dataUrodzenia) : this (imie, nazwisko)
            //konstruktor z 3 parametrami wykorzystujacy konstruktor z 2 parametrami
        {
            this.dataUrodzenia = dataUrodzenia;
        }
        #endregion
        #region destruktor
        ~Pracownik()
        {
            Console.WriteLine("Usunieto obiekt pracownika: " + this.GetHashCode());
            Console.ReadLine();
        }
        #endregion //destruktor
        #region wlasciwosci
        public string Imie
        {
            get
            {
                return imie;
            }

            set
            {
                /*
                if (value.Length>1) imie = value;

                else throw new PracownikException()
                {
                    danePracownik = this.imie + " " + this.nazwisko,
                    komunikat = "IMIE musi miec minimum 2 znaki"
                };
                */
                var wr = new System.Text.RegularExpressions.Regex(@"\d");
                if (wr.IsMatch(value))  throw new PracownikException()
                    {
                        danePracownik = value + " " + this.nazwisko,
                        komunikat = "IMIE nie moze zawierac cyfry"
                    };
                
                else
                {
                    imie = value;
                };
                
                
                


            }
        }
        #endregion
        #region akcesory
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
        public void ustawNazwisko(string nazwisko)
        {
            if (nazwisko.Length > 1)
            {
                this.nazwisko = nazwisko;
            }
            else
            {
                throw new PracownikException()
                {
                    danePracownik = this.imie + " " + this.nazwisko,
                    komunikat = "NAZWISKO musi miec wiecej conajmniej dwa znaki"
                };
            }
        }
        public string pobierzNazwisko()
        {
            return nazwisko;
        }
        #endregion

        #region metody
        /*
                public float operacjeLacznie()
                {
                    float suma = 0;
                    foreach (var operacja in this.operacje)
                    {
                        suma += operacja.kwota;
                    }
                    return suma;
                }
        */
        public float operacjeLacznie() //wersja korzystajaca z jezyka LINQ
        {
            return operacje.Sum(operacja => operacja.kwota);
        }
        /*
                public float operacjeLacznie(DateTime dataOd, DateTime dataDo)
                {
                    float suma = 0;
                    foreach (var operacja in this.operacje)
                    {
                        if (operacja.data > dataOd && operacja.data < dataDo)
                        {
                            suma += operacja.kwota;
                        }
                    }
                    return suma;

                }
        */
        public float operacjeLacznie(DateTime dataOd, DateTime dataDo)
        {
            return operacje.Where(oper => oper.data >= dataOd && oper.data <= dataDo).Sum(oper => oper.kwota);
        }
        #endregion
    }
}

    public enum UmowaTyp
    {
        OPrace, Dzieło, Zlecenie, Kontrakt //
    }
    