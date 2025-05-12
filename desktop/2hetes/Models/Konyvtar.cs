using System;
using System.Collections.Generic;
using System.Linq;

namespace VarosiSzolgaltato.Models
{
    public class Konyvtar
    {
        private List<Konyv> konyvek;
        private int maxKapacitas;
        private List<(Lakos lakos, Konyv konyv, DateTime kolcsonzesIdeje)> kolcsonzesek;

        public Konyvtar(int maxKapacitas = 1000)
        {
            if (maxKapacitas <= 0)
                throw new ArgumentException("A maximális kapacitás pozitív kell legyen!", nameof(maxKapacitas));

            this.maxKapacitas = maxKapacitas;
            konyvek = new List<Konyv>();
            kolcsonzesek = new List<(Lakos, Konyv, DateTime)>();
        }

        public bool Belepes(Lakos lakos)
        {
            if (lakos == null)
                throw new ArgumentNullException(nameof(lakos));
            
            return true;
        }

        public bool Kolcsonoz(Lakos lakos, Konyv konyv)
        {
            if (lakos == null)
                throw new ArgumentNullException(nameof(lakos));
            if (konyv == null)
                throw new ArgumentNullException(nameof(konyv));

            if (!konyvek.Contains(konyv) || konyv.GetPeldanyszam() <= 0)
                return false;

            konyv.CsokkentPeldanyszam();
            kolcsonzesek.Add((lakos, konyv, DateTime.Now));
            return true;
        }

        public bool Visszahoz(Lakos lakos, Konyv konyv)
        {
            if (lakos == null)
                throw new ArgumentNullException(nameof(lakos));
            if (konyv == null)
                throw new ArgumentNullException(nameof(konyv));

            var kolcsonzes = kolcsonzesek.FirstOrDefault(k => 
                k.lakos == lakos && k.konyv == konyv);

            if (kolcsonzes == default)
                return false;

            kolcsonzesek.Remove(kolcsonzes);
            konyv.NovelPeldanyszam();
            return true;
        }

        public void KonyvHozzaadasa(Konyv konyv)
        {
            if (konyv == null)
                throw new ArgumentNullException(nameof(konyv));
            if (konyvek.Count >= maxKapacitas)
                throw new InvalidOperationException("A könyvtár elérte a maximális kapacitását!");

            konyvek.Add(konyv);
        }

        public List<Konyv> GetKonyvek() => new List<Konyv>(konyvek);
        public int GetMaxKapacitas() => maxKapacitas;
    }
} 