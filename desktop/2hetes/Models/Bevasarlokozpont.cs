using System;
using System.Collections.Generic;

namespace VarosiSzolgaltato.Models
{
    public class Bolt
    {
        public string Nev { get; }
        public string Tipus { get; }
        public decimal BevetelOsszeg { get; private set; }

        public Bolt(string nev, string tipus)
        {
            if (string.IsNullOrEmpty(nev))
                throw new ArgumentException("A név nem lehet üres!", nameof(nev));
            if (string.IsNullOrEmpty(tipus))
                throw new ArgumentException("A típus nem lehet üres!", nameof(tipus));

            Nev = nev;
            Tipus = tipus;
            BevetelOsszeg = 0;
        }

        public void NoveliBevetel(decimal osszeg)
        {
            if (osszeg <= 0)
                throw new ArgumentException("A bevétel növelése csak pozitív összeggel lehetséges!", nameof(osszeg));

            BevetelOsszeg += osszeg;
        }
    }

    public class Bevasarlokozpont
    {
        private List<Bolt> boltok;
        private HashSet<Lakos> latogatok;
        private Dictionary<Bolt, List<Lakos>> boltLatogatok;

        public Bevasarlokozpont()
        {
            boltok = new List<Bolt>();
            latogatok = new HashSet<Lakos>();
            boltLatogatok = new Dictionary<Bolt, List<Lakos>>();
        }

        public void UjBolt(string nev, string tipus)
        {
            var bolt = new Bolt(nev, tipus);
            boltok.Add(bolt);
            boltLatogatok[bolt] = new List<Lakos>();
        }

        public bool Belep(Lakos latogato)
        {
            if (latogato == null)
                throw new ArgumentNullException(nameof(latogato));

            return latogatok.Add(latogato);
        }

        public bool Kolt(Lakos latogato, Bolt bolt, decimal osszeg)
        {
            if (latogato == null)
                throw new ArgumentNullException(nameof(latogato));
            if (bolt == null)
                throw new ArgumentNullException(nameof(bolt));
            if (osszeg <= 0)
                throw new ArgumentException("A költés összege pozitív kell legyen!", nameof(osszeg));

            if (!latogatok.Contains(latogato) || !boltok.Contains(bolt))
                return false;

            if (latogato.Fizet(osszeg))
            {
                bolt.NoveliBevetel(osszeg);
                if (!boltLatogatok[bolt].Contains(latogato))
                    boltLatogatok[bolt].Add(latogato);
                return true;
            }

            return false;
        }

        public void Kilep(Lakos latogato)
        {
            if (latogato == null)
                throw new ArgumentNullException(nameof(latogato));

            latogatok.Remove(latogato);
            foreach (var bolt in boltok)
            {
                boltLatogatok[bolt].Remove(latogato);
            }
        }

        public List<Bolt> GetBoltok() => new List<Bolt>(boltok);
        public HashSet<Lakos> GetLatogatok() => new HashSet<Lakos>(latogatok);
        public Dictionary<Bolt, List<Lakos>> GetBoltLatogatok() => 
            new Dictionary<Bolt, List<Lakos>>(boltLatogatok);
    }
} 