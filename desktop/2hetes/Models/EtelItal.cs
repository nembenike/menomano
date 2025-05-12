using System;

namespace VarosiSzolgaltato.Models
{
    public enum EtelItalTipus
    {
        Etel,
        Ital
    }

    public class EtelItal
    {
        private string nev;
        private decimal ar;
        private EtelItalTipus tipus;
        private int koffeinTartalom;
        private int kaloria;

        public EtelItal(string nev, decimal ar, EtelItalTipus tipus, int koffeinTartalom, int kaloria)
        {
            if (string.IsNullOrEmpty(nev))
                throw new ArgumentException("A név nem lehet üres!", nameof(nev));
            if (ar <= 0)
                throw new ArgumentException("Az ár pozitív kell legyen!", nameof(ar));
            if (koffeinTartalom < 0)
                throw new ArgumentException("A koffein tartalom nem lehet negatív!", nameof(koffeinTartalom));
            if (kaloria < 0)
                throw new ArgumentException("A kalória nem lehet negatív!", nameof(kaloria));

            this.nev = nev;
            this.ar = ar;
            this.tipus = tipus;
            this.koffeinTartalom = koffeinTartalom;
            this.kaloria = kaloria;
        }

        public string GetNev() => nev;
        public decimal GetAr() => ar;
        public EtelItalTipus GetTipus() => tipus;
        public int GetKoffeinTartalom() => koffeinTartalom;
        public int GetKaloria() => kaloria;
    }
} 