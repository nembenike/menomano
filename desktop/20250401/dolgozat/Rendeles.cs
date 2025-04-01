namespace Etterem {
    class Rendeles {
        public Vendeg vendeg { get; set; }
        public List<Menuelem> rendelesek { get; set; }

        public Rendeles(Vendeg vendeg, List<Menuelem> rendelesek) {
            this.vendeg = vendeg;
            this.rendelesek = rendelesek;
        }

        public int Vegosszeg() {
            return rendelesek.Sum(m => m.ar);
        }

        public override string ToString() {
            string rendelesekStr = string.Join(", ", rendelesek.Select(m => m.nev));
            return $"Vendég: {vendeg.nev}, Rendelések: {rendelesekStr}, Végösszeg: {Vegosszeg()} Ft";
        }
    }
}