using System;
using System.Collections.Generic;

namespace VarosiSzolgaltato.Models
{
    public class Varos
    {
        private List<Lakos> lakosok;
        private Konyvtar konyvtar;
        private List<KozlekedesiJarmu> jarmuvek;
        private Posta posta;
        private Kavezo kavezo;
        private Bevasarlokozpont bevasarlokozpont;

        public Varos()
        {
            lakosok = new List<Lakos>();
            jarmuvek = new List<KozlekedesiJarmu>();
        }

        public void HozzaadLakos(Lakos lakos)
        {
            if (lakos == null)
                throw new ArgumentNullException(nameof(lakos));
            
            lakosok.Add(lakos);
        }

        public void HozzaadJarmu(KozlekedesiJarmu jarmu)
        {
            if (jarmu == null)
                throw new ArgumentNullException(nameof(jarmu));
            
            jarmuvek.Add(jarmu);
        }

        public void SzolgaltatasInditasa(string tipus)
        {
            switch (tipus.ToLower())
            {
                case "konyvtar":
                    konyvtar = new Konyvtar();
                    break;
                case "posta":
                    posta = new Posta();
                    break;
                case "kavezo":
                    kavezo = new Kavezo();
                    break;
                case "bevasarlokozpont":
                    bevasarlokozpont = new Bevasarlokozpont();
                    break;
                default:
                    throw new ArgumentException("Ismeretlen szolgáltatás típus");
            }
        }

        public void NapFutasa()
        {
            foreach (var jarmu in jarmuvek)
            {
                jarmu.Lepes();
            }
        }

        public string VarosStatusza()
        {
            return $"Lakosok száma: {lakosok.Count}\n" +
                   $"Könyvtár: {(konyvtar != null ? "Működik" : "Nem működik")}\n" +
                   $"Járművek száma: {jarmuvek.Count}\n" +
                   $"Posta: {(posta != null ? "Működik" : "Nem működik")}\n" +
                   $"Kávézó: {(kavezo != null ? "Működik" : "Nem működik")}\n" +
                   $"Bevásárlóközpont: {(bevasarlokozpont != null ? "Működik" : "Nem működik")}";
        }
    }
} 