using System;
using System.Collections.Generic;
using System.Linq;

namespace VarosiSzolgaltato.Models
{
    public class Posta
    {
        private Queue<Csomag> csomagok;
        private List<Csomag> kiszallitasraVaro;
        private List<Csomag> kiszallitott;

        public Posta()
        {
            csomagok = new Queue<Csomag>();
            kiszallitasraVaro = new List<Csomag>();
            kiszallitott = new List<Csomag>();
        }

        public void Kuldes(Csomag csomag)
        {
            if (csomag == null)
                throw new ArgumentNullException(nameof(csomag));

            csomagok.Enqueue(csomag);
            csomag.Feladas();
        }

        public bool Atvetel(Lakos cimzett, Csomag csomag)
        {
            if (cimzett == null)
                throw new ArgumentNullException(nameof(cimzett));
            if (csomag == null)
                throw new ArgumentNullException(nameof(csomag));

            if (!kiszallitasraVaro.Contains(csomag) || csomag.GetCimzett() != cimzett)
                return false;

            if (cimzett.Fizet(csomag.GetAr()))
            {
                kiszallitasraVaro.Remove(csomag);
                kiszallitott.Add(csomag);
                csomag.Kiszallitas();
                return true;
            }

            return false;
        }

        public void SorbanAllas()
        {
            if (csomagok.Count > 0)
            {
                var csomag = csomagok.Dequeue();
                csomag.Szallitas();
                kiszallitasraVaro.Add(csomag);
            }
        }

        public int GetVarakozoCsomagokSzama() => csomagok.Count;
        public int GetKiszallitasraVaroCsomagokSzama() => kiszallitasraVaro.Count;
        public int GetKiszallitottCsomagokSzama() => kiszallitott.Count;
        public List<Csomag> GetKiszallitasraVaroCsomagok() => new List<Csomag>(kiszallitasraVaro);
    }
} 