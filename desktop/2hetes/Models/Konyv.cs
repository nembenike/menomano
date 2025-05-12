using System;

namespace VarosiSzolgaltato.Models
{
    public class Konyv
    {
        private string cim;
        private string szerzo;
        private int oldalszam;
        private decimal ertek;
        private int peldanyszam;

        public Konyv(string cim, string szerzo, int oldalszam, decimal ertek, int peldanyszam)
        {
            if (string.IsNullOrEmpty(cim))
                throw new ArgumentException("A cím nem lehet üres!", nameof(cim));
            if (string.IsNullOrEmpty(szerzo))
                throw new ArgumentException("A szerző nem lehet üres!", nameof(szerzo));
            if (oldalszam <= 0)
                throw new ArgumentException("Az oldalszám pozitív kell legyen!", nameof(oldalszam));
            if (ertek <= 0)
                throw new ArgumentException("Az érték pozitív kell legyen!", nameof(ertek));
            if (peldanyszam < 0)
                throw new ArgumentException("A példányszám nem lehet negatív!", nameof(peldanyszam));

            this.cim = cim;
            this.szerzo = szerzo;
            this.oldalszam = oldalszam;
            this.ertek = ertek;
            this.peldanyszam = peldanyszam;
        }

        public void NovelPeldanyszam()
        {
            peldanyszam++;
        }

        public void CsokkentPeldanyszam()
        {
            if (peldanyszam <= 0)
                throw new InvalidOperationException("Nincs több példány a könyvből!");
            peldanyszam--;
        }

        public string GetCim() => cim;
        public string GetSzerzo() => szerzo;
        public int GetOldalszam() => oldalszam;
        public decimal GetErtek() => ertek;
        public int GetPeldanyszam() => peldanyszam;
    }
} 