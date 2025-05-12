using System;

namespace VarosiSzolgaltato.Models
{
    public enum CsomagAllapot
    {
        Letrehozva,
        Feladva,
        Szallitas,
        Kiszallitva
    }

    public class Csomag
    {
        private Lakos kuldo;
        private Lakos cimzett;
        private double suly;
        private decimal ar;
        private CsomagAllapot allapot;

        public Csomag(Lakos kuldo, Lakos cimzett, double suly, decimal ar)
        {
            if (kuldo == null)
                throw new ArgumentNullException(nameof(kuldo));
            if (cimzett == null)
                throw new ArgumentNullException(nameof(cimzett));
            if (suly <= 0)
                throw new ArgumentException("A súly pozitív kell legyen!", nameof(suly));
            if (ar <= 0)
                throw new ArgumentException("Az ár pozitív kell legyen!", nameof(ar));

            this.kuldo = kuldo;
            this.cimzett = cimzett;
            this.suly = suly;
            this.ar = ar;
            this.allapot = CsomagAllapot.Letrehozva;
        }

        public void Feladas()
        {
            if (allapot != CsomagAllapot.Letrehozva)
                throw new InvalidOperationException("A csomag már fel van adva!");
            
            allapot = CsomagAllapot.Feladva;
        }

        public void Szallitas()
        {
            if (allapot != CsomagAllapot.Feladva)
                throw new InvalidOperationException("A csomag még nincs feladva vagy már kiszállítás alatt van!");
            
            allapot = CsomagAllapot.Szallitas;
        }

        public void Kiszallitas()
        {
            if (allapot != CsomagAllapot.Szallitas)
                throw new InvalidOperationException("A csomag nincs szállítás alatt!");
            
            allapot = CsomagAllapot.Kiszallitva;
        }

        public Lakos GetKuldo() => kuldo;
        public Lakos GetCimzett() => cimzett;
        public double GetSuly() => suly;
        public decimal GetAr() => ar;
        public CsomagAllapot GetAllapot() => allapot;
    }
} 