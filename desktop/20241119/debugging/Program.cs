/*
2024.11.19 Asztali Alkalmazáas fejlesztés
Berényi Bence 11.D

Debugged Program can be seen in Original.cs.bak
*/

namespace DebuggFeladat
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<string> vasarlolista = new List<string>();
        static List<int> mennyisegek = new List<int>();

        static string[] raktarTermekek = new string[10];
        static int[] raktarMennyisegek = new int[10];

        static void Main()
        {
            bool fut = true;
            while (fut)
            {
                Console.WriteLine("Bevásárlólista és Raktárkezelő Rendszer");
                Console.WriteLine("1. Új termék hozzáadása a bevásárlólistához");
                Console.WriteLine("2. Termék eltávolítása a bevásárlólistáról");
                Console.WriteLine("3. Raktárkészlet frissítése");
                Console.WriteLine("4. Bevásárlólista megtekintése");
                Console.WriteLine("5. Raktárkészlet megtekintése");
                Console.WriteLine("6. Bevásárlás szimuláció");
                Console.WriteLine("7. Kilépés");
                Console.Write("Válassz egy opciót: ");
    
                int opcio = Convert.ToInt32(Console.ReadLine()); 

                switch (opcio)
                {
                    case 1:
                        Hozzaadas();
                        break;
                    case 2:
                        TermekTorlese();
                        break;
                    case 3:
                        RaktarFrissites();
                        break;
                    case 4:
                        ListaMegtekintes();
                        break;
                    case 5:
                        RaktarMegtekintes();
                        break;
                    case 6:
                        Vasarlas();
                        break;
                    case 7:
                        Console.WriteLine("Kilépés...");
                        fut = false;
                        break;
                    default:
                        Console.WriteLine("Érvénytelen opció!");
                        break;
                }
            }
        }

        static void Hozzaadas()
        {
            Console.Write("Add meg a termék nevét: ");
            string termek = Console.ReadLine();
            if (termek == null)
            {
                Console.WriteLine("A termék neve nem lehet üres!");
                return;
            }

            Console.Write("Add meg a mennyiséget: ");
            int mennyiseg = Convert.ToInt32(Console.ReadLine());

            if (mennyiseg < 0)
            {
                Console.WriteLine("A mennyiség nem lehet negatív!");
                return;
            }

            vasarlolista.Add(termek);
            mennyisegek.Add(mennyiseg);
            Console.WriteLine("Termék hozzáadva a bevásárlólistához!");
        }

        static void TermekTorlese()
        {
            Console.Write("Add meg a törölni kívánt termék nevét: ");
            string termek = Console.ReadLine();

            if (!vasarlolista.Contains(termek))
            {
                Console.WriteLine("Ez a termék nincs a listán!");
            }
            else
            {
                int index = vasarlolista.IndexOf(termek);
                vasarlolista.RemoveAt(index);
                mennyisegek.RemoveAt(index);
                Console.WriteLine("Termék eltávolítva a bevásárlólistáról!");
            }
        }

        static void ListaMegtekintes()
        {
            Console.WriteLine("Bevásárlólista:");
            for (int i = 0; i < vasarlolista.Count; i++)
            {
                Console.WriteLine($"- {vasarlolista[i]}: {mennyisegek[i]} db");
            }
        }

        static void RaktarFrissites()
        {
            Console.Write("Add meg a termék nevét: ");
            string termek = Console.ReadLine();

            int index = Array.IndexOf(raktarTermekek, termek);
            if (index == -1)
            {
                index = Array.IndexOf(raktarTermekek, null);
                if (index == -1)
                {
                    Console.WriteLine("A raktár tele van!");
                    return;
                }
                raktarTermekek[index] = termek;
            }

            Console.Write("Add meg a frissítendő mennyiséget (pozitív/nem negatív szám): ");
            int mennyiseg = Convert.ToInt32(Console.ReadLine());

            if (mennyiseg < 0)
            {
                Console.WriteLine("Hiba: negatív mennyiséget nem adhatsz hozzá!");
                return;
            }

            raktarMennyisegek[index] = mennyiseg;
            Console.WriteLine("A raktárkészlet frissítve!");
        }


        static void RaktarMegtekintes()
        {
            Console.WriteLine("Raktárkészlet:");
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (raktarTermekek[i] == null)
                {
                    Console.WriteLine($"- Nincs termék a {i + 1}. helyen.");
                }
                else
                {
                    Console.WriteLine($"- {raktarTermekek[i]}: {raktarMennyisegek[i]} db");
                }
            }
        }

        static void Vasarlas()
        {
            Console.WriteLine("Bevásárlás folyamatban...");
            for (int i = 0; i < vasarlolista.Count; i++)
            {
                string termek = vasarlolista[i];
                int mennyiseg = mennyisegek[i];

                int index = Array.IndexOf(raktarTermekek, termek);
                if (index == -1)
                {
                    Console.WriteLine($"Nincs a raktárban: {termek}");
                    continue;
                }

                if (raktarMennyisegek[index] < mennyiseg)
                {
                    Console.WriteLine($"Nincs elég {termek} a raktárban!");
                }
                else
                {
                    raktarMennyisegek[index] -= mennyiseg;
                    Console.WriteLine($"Sikeresen megvásárolt: {termek}, {mennyiseg} db.");
                }
            }

            vasarlolista.Clear();
            mennyisegek.Clear();
        }
    }
}
