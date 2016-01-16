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
            Pracownik p1 = new Pracownik("Beata","TT");
            p1.ID = 10;
            p1.ustawPesel(12345612345);
            p1.umowa = UmowaTyp.Dzieło;
            p1.wynagrodzenie = new Wynagrodzenie();
            p1.wynagrodzenie.pensjaPodstawowa = 10000f;
            p1.wynagrodzenie.premia = 10000000f;
            p1.wynagrodzenie.waluta = "ruble jarosławskie";
            p1.operacje = new Operacja[2];

            Operacja o1 = new Operacja();
            o1.data = new DateTime(2011, 03, 01);
            o1.tytul = "Wypłata za knucie";
            o1.kwota = 3333f;
            o1.wykonanie = true;

            Operacja o2 = new Operacja();
            o2.data = new DateTime(2009, 03, 01);
            o2.tytul = "Opieka nad kotem";
            o2.kwota = 4444f;
            o2.wykonanie = true;

            p1.operacje[0] = o1;
            p1.operacje[1] = o2;

            var p2 = new Pracownik("jan","Lis",new DateTime(1939,9,1))
            {
                ID = 2222,
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
                p2.ustawNazwisko("lis");
            pracownicy[0] = p1;
            pracownicy[1] = p2;

            foreach (var pracownik in pracownicy)
            {
                Console.WriteLine(pracownik.pobierzPesel().ToString() + " : " + pracownik.Imie + " " + pracownik.pobierzNazwisko() + " " + pracownik.wynagrodzenie.wygrodzenieLaczne().ToString("N")+" "+pracownik.wynagrodzenie.waluta);
                Console.WriteLine("Operacje lacznie: " + pracownik.operacjeLacznie().ToString("N"));
                Console.WriteLine("Operacje od do :" + pracownik.operacjeLacznie(new DateTime(2010, 03, 01), new DateTime(2015, 03, 01)));
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
