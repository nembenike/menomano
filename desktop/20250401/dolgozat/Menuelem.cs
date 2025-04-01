namespace Etterem {
    class Menuelem {
        public string nev { get; set; }
        public int ar { get; set; }
        public string kategoria { get; set; }

        public Menuelem(string nev, int ar, string kategoria) {
            this.nev = nev;
            this.ar = ar;
            this.kategoria = kategoria;
        }
        public override string ToString() {
            return $"{nev} ({kategoria}) - {ar} Ft";
        }
        public string ToCSV() {
            return $"{nev};{ar};{kategoria}";
        }
    }
}