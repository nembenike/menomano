namespace Etterem {
    class Vendeg {
        public string nev { get; set; }
        public List<Menuelem> rendelesek { get; set; }

        public Vendeg(string nev) {
            this.nev = nev;
            this.rendelesek = new List<Menuelem>();
        }

        public void Rendel(Menuelem menuelem) {
            rendelesek.Add(menuelem);
            System.Console.WriteLine($"{nev} rendelt egy {menuelem.nev}-t.");
        }
    }
}