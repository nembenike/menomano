using System;
using VarosiSzolgaltato.Models;
using System.Linq;

namespace VarosiSzolgaltato
{
    class Program
    {
        static void Main(string[] args)
        {
            var varos = new Varos();

            var lakosok = new[]
            {
                new Lakos("Nagy János", 35, "Dózsa György út 9", 100000),
                new Lakos("Kiss Éva", 28, "Dózsa György út 9", 80000),
                new Lakos("Szabó Péter", 42, "Dózsa György út 9", 150000),
                new Lakos("Kovács Anna", 31, "Dózsa György út 9", 95000),
                new Lakos("Tóth Béla", 45, "Dózsa György út 9", 120000),
                new Lakos("Horváth Mária", 39, "Dózsa György út 9", 110000),
                new Lakos("Varga István", 52, "Dózsa György út 9", 130000),
                new Lakos("Molnár Katalin", 29, "Dózsa György út 9", 85000),
                new Lakos("Balogh Gábor", 33, "Dózsa György út 9", 105000),
                new Lakos("Fekete Zsuzsa", 37, "Dózsa György út 9", 115000)
            };

            foreach (var lakos in lakosok)
            {
                varos.HozzaadLakos(lakos);
            }

            varos.SzolgaltatasInditasa("konyvtar");
            var konyvtar = new Konyvtar();
            var konyvek = new[]
            {
                new Konyv("Az ember tragédiája", "Madách Imre", 200, 3500, 3),
                new Konyv("Egri csillagok", "Gárdonyi Géza", 400, 4200, 5),
                new Konyv("A Pál utcai fiúk", "Molnár Ferenc", 250, 3200, 4),
                new Konyv("Légy jó mindhalálig", "Móricz Zsigmond", 300, 3800, 3),
                new Konyv("János vitéz", "Petőfi Sándor", 150, 2800, 6)
            };

            foreach (var konyv in konyvek)
            {
                konyvtar.KonyvHozzaadasa(konyv);
            }

            Console.WriteLine("Könyvtári kölcsönzések:");
            konyvtar.Belepes(lakosok[0]);
            konyvtar.Kolcsonoz(lakosok[0], konyvek[0]);
            konyvtar.Belepes(lakosok[1]);
            konyvtar.Kolcsonoz(lakosok[1], konyvek[1]);
            konyvtar.Belepes(lakosok[2]);
            konyvtar.Kolcsonoz(lakosok[2], konyvek[2]);

            var jarmu = new KozlekedesiJarmu(
                "7-es busz",
                new[] { "Központi állomás", "Kórház", "Piac", "Iskola", "Bevásárlóközpont" },
                50,
                400
            );
            varos.HozzaadJarmu(jarmu);

            Console.WriteLine("\nKözlekedési szimuláció:");
            for (int i = 0; i < 5; i++)
            {
                if (lakosok[i].HasznalKozlekedest(jarmu))
                {
                    Console.WriteLine($"{lakosok[i].GetNev()} felszállt a buszra");
                }
            }

            varos.SzolgaltatasInditasa("kavezo");
            var kavezo = new Kavezo();
            
            var kave = new EtelItal("Espresso", 450, EtelItalTipus.Ital, 80, 0);
            var suti = new EtelItal("Túrós batyu", 350, EtelItalTipus.Etel, 0, 320);
            
            kavezo.MenuHozzaadas(kave);
            kavezo.MenuHozzaadas(suti);

            Console.WriteLine("\nKávézó szimuláció:");
            if (kavezo.Rendel(lakosok[0], kave))
            {
                Console.WriteLine($"{lakosok[0].GetNev()} rendelt egy {kave.GetNev()}-t");
                kavezo.Fogyaszt(lakosok[0], kave);
            }

            if (kavezo.Rendel(lakosok[0], suti))
            {
                Console.WriteLine($"{lakosok[0].GetNev()} rendelt egy {suti.GetNev()}-t");
                kavezo.Fogyaszt(lakosok[0], suti);
            }

            varos.SzolgaltatasInditasa("posta");
            var posta = new Posta();
            
            Console.WriteLine("\nPosta szimuláció:");
            var csomag = new Csomag(lakosok[0], lakosok[1], 2.5, 1500);
            posta.Kuldes(csomag);
            Console.WriteLine($"{csomag.GetKuldo().GetNev()} csomagot küldött {csomag.GetCimzett().GetNev()}-nak/nek");
            
            posta.SorbanAllas();
            posta.Atvetel(lakosok[1], csomag);
            Console.WriteLine($"{csomag.GetCimzett().GetNev()} átvette a csomagot");

            varos.SzolgaltatasInditasa("bevasarlokozpont");
            var bevasarlokozpont = new Bevasarlokozpont();
            
            Console.WriteLine("\nBevásárlóközpont szimuláció:");
            bevasarlokozpont.UjBolt("Ruházati Bolt", "Ruházat");
            bevasarlokozpont.UjBolt("Elektronikai Szaküzlet", "Elektronika");
            bevasarlokozpont.UjBolt("Élelmiszer Áruház", "Élelmiszer");

            bevasarlokozpont.Belep(lakosok[0]);
            bevasarlokozpont.Belep(lakosok[1]);
            
            var ruhazatiBolt = bevasarlokozpont.GetBoltok().First(b => b.Tipus == "Ruházat");
            var elektronikaBolt = bevasarlokozpont.GetBoltok().First(b => b.Tipus == "Elektronika");
            
            if (bevasarlokozpont.Kolt(lakosok[0], ruhazatiBolt, 15000))
            {
                Console.WriteLine($"{lakosok[0].GetNev()} vásárolt a {ruhazatiBolt.Nev}-ban {15000} Ft értékben");
            }
            
            if (bevasarlokozpont.Kolt(lakosok[1], elektronikaBolt, 50000))
            {
                Console.WriteLine($"{lakosok[1].GetNev()} vásárolt a {elektronikaBolt.Nev}-ben {50000} Ft értékben");
            }

            Console.WriteLine("\nVáros statisztika:");
            Console.WriteLine(varos.VarosStatusza());
        }
    }
}
