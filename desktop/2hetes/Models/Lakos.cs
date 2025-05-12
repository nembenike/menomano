using System;

namespace VarosiSzolgaltato.Models
{
    public class Lakos
    {
        private string nev;
        private int eletkor;
        private string lakcim;
        private decimal penzosszeg;

        public Lakos(string nev, int eletkor, string lakcim, decimal kezdoPenz)
        {
            if (string.IsNullOrEmpty(nev))
                throw new ArgumentException("A név nem lehet üres!", nameof(nev));
            if (eletkor < 0)
                throw new ArgumentException("Az életkor nem lehet negatív!", nameof(eletkor));
            if (string.IsNullOrEmpty(lakcim))
                throw new ArgumentException("A lakcím nem lehet üres!", nameof(lakcim));
            if (kezdoPenz < 0)
                throw new ArgumentException("A kezdő pénzösszeg nem lehet negatív!", nameof(kezdoPenz));

            this.nev = nev;
            this.eletkor = eletkor;
            this.lakcim = lakcim;
            this.penzosszeg = kezdoPenz;
        }

        public bool Fizet(decimal osszeg)
        {
            if (osszeg <= 0)
                throw new ArgumentException("A fizetendő összeg pozitív kell legyen!", nameof(osszeg));

            if (penzosszeg >= osszeg)
            {
                penzosszeg -= osszeg;
                return true;
            }
            return false;
        }

        public bool BelepSzolgaltatasba(string szolgaltatasNev)
        {
            return true;
        }

        public bool HasznalKozlekedest(KozlekedesiJarmu jarmu)
        {
            if (jarmu == null)
                throw new ArgumentNullException(nameof(jarmu));

            return Fizet(jarmu.JegyAr) && jarmu.Felszallas(this);
        }

        public string GetNev() => nev;
        public int GetEletkor() => eletkor;
        public string GetLakcim() => lakcim;
        public decimal GetPenzosszeg() => penzosszeg;
    }
} 