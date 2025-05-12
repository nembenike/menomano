using System;
using System.Collections.Generic;

namespace VarosiSzolgaltato.Models
{
    public class Kavezo
    {
        private List<EtelItal> menu;
        private List<Lakos> vendegek;
        private Dictionary<Lakos, List<EtelItal>> rendelesek;

        public Kavezo()
        {
            menu = new List<EtelItal>();
            vendegek = new List<Lakos>();
            rendelesek = new Dictionary<Lakos, List<EtelItal>>();
        }

        public void MenuHozzaadas(EtelItal tetel)
        {
            if (tetel == null)
                throw new ArgumentNullException(nameof(tetel));

            menu.Add(tetel);
        }

        public bool Rendel(Lakos vendeg, EtelItal tetel)
        {
            if (vendeg == null)
                throw new ArgumentNullException(nameof(vendeg));
            if (tetel == null)
                throw new ArgumentNullException(nameof(tetel));

            if (!menu.Contains(tetel))
                return false;

            if (!vendegek.Contains(vendeg))
                vendegek.Add(vendeg);

            if (!rendelesek.ContainsKey(vendeg))
                rendelesek[vendeg] = new List<EtelItal>();

            if (vendeg.Fizet(tetel.GetAr()))
            {
                rendelesek[vendeg].Add(tetel);
                return true;
            }

            return false;
        }

        public void Fogyaszt(Lakos vendeg, EtelItal tetel)
        {
            if (vendeg == null)
                throw new ArgumentNullException(nameof(vendeg));
            if (tetel == null)
                throw new ArgumentNullException(nameof(tetel));

            if (rendelesek.ContainsKey(vendeg) && rendelesek[vendeg].Contains(tetel))
            {
                rendelesek[vendeg].Remove(tetel);
                if (rendelesek[vendeg].Count == 0)
                {
                    rendelesek.Remove(vendeg);
                    vendegek.Remove(vendeg);
                }
            }
        }

        public List<EtelItal> GetMenu() => new List<EtelItal>(menu);
        public List<Lakos> GetVendegek() => new List<Lakos>(vendegek);
        public Dictionary<Lakos, List<EtelItal>> GetRendelesek() => 
            new Dictionary<Lakos, List<EtelItal>>(rendelesek);
    }
} 