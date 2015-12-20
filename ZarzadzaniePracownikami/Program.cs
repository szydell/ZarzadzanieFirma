using Pracownicy.Finanse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZarzadzaniePracownikami
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Pracownik[] pracownicy = new Pracownik[2];
            Pracownik p1 = new Pracownik();
            p1.ID = 10;
            p1.imie = "Beata";
            p1.nazwisko = "Tępa";
            p1.ustawPesel(111111111);
            p1.umowa = UmowaTyp.Dzieło;
            p1.wynagrodzenie = new Wynagrodzenie();
            p1.wynagrodzenie.pensjaPodstawowa = 10000f;
            p1.wynagrodzenie.premia = 10000000f;
            p1.wynagrodzenie.waluta = "ruble jarosławskie";
            p1.operacje = new Operacja[2];

            Operacja o1 = new Operacja();
            o1.tytul = "Wypłata za knucie";
            o1.kwota = 3333f;
            o1.wykonanie = true;

            Operacja o2 = new Operacja();
            o2.tytul = "Opieka nad kotem";
            o2.kwota = 4444f;
            o2.wykonanie = true;

            p1.operacje[0] = o1;
            p1.operacje[1] = o2;

            var p2 = new Pracownik()
            {
                ID = 2222,
                imie = "jan",
                nazwisko = "lis",
                umowa = UmowaTyp.Dzieło,
                wynagrodzenie = new Wynagrodzenie()
                {
                    pensjaPodstawowa = 1111f,
                    premia = 111f,
                    waluta = "złoty"            
                },
                operacje = new Operacja[2]
                {
                    new Operacja() {kwota=1122f,tytul="AAA",wykonanie=false},
                    new Operacja() {kwota=33f,tytul="BBB",wykonanie=true}
                }
            };
            p2.ustawPesel(12345678901);

            pracownicy[0] = p1;
            pracownicy[1] = p2;

            foreach (var pracownik in pracownicy)
            {
                Console.WriteLine(pracownik.pobierzPesel().ToString() + " : " + pracownik.imie + " " + pracownik.nazwisko);

                foreach (var operacja in pracownik.operacje)
                {
                    Console.WriteLine(operacja.tytul + ": " + operacja.kwota);
                }
            }
            }
            catch(PracownikException ex)
            {
                Console.WriteLine(ex.komunikat+": "+ex.danePracownik);
            }
            Console.ReadLine();
            //pracownicy[0] = 
        }
    }
}
