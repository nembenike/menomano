using System;
using System.Collections.Generic;

namespace VarosiSzolgaltato.Models
{
    public class KozlekedesiJarmu
    {
        private string nev;
        private string[] utvonal;
        private int ferohely;
        private decimal jegyar;
        private List<Lakos> utasok;
        private int aktualisMegallo;

        public KozlekedesiJarmu(string nev, string[] utvonal, int ferohely, decimal jegyar)
        {
            if (string.IsNullOrEmpty(nev))
                throw new ArgumentException("A név nem lehet üres!", nameof(nev));
            if (utvonal == null || utvonal.Length < 2)
                throw new ArgumentException("Az útvonalnak legalább két megállót tartalmaznia kell!", nameof(utvonal));
            if (ferohely <= 0)
                throw new ArgumentException("A férőhely pozitív kell legyen!", nameof(ferohely));
            if (jegyar <= 0)
                throw new ArgumentException("A jegyár pozitív kell legyen!", nameof(jegyar));

            this.nev = nev;
            this.utvonal = utvonal;
            this.ferohely = ferohely;
            this.jegyar = jegyar;
            this.utasok = new List<Lakos>();
            this.aktualisMegallo = 0;
        }

        public bool Felszallas(Lakos utas)
        {
            if (utas == null)
                throw new ArgumentNullException(nameof(utas));

            if (utasok.Count >= ferohely)
                return false;

            utasok.Add(utas);
            return true;
        }

        public void Lepes()
        {
            aktualisMegallo = (aktualisMegallo + 1) % utvonal.Length;
        }

        public string GetNev() => nev;
        public string[] GetUtvonal() => utvonal;
        public int GetFerohely() => ferohely;
        public decimal JegyAr => jegyar;
        public string GetAktualisMegallo() => utvonal[aktualisMegallo];
        public int GetUtasokSzama() => utasok.Count;
    }
} 