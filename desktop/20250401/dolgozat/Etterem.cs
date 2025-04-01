namespace Etterem {
    class Etterem {
        public List<Menuelem> Menu { get; set; }
        public List<Rendeles> Rendelesek { get; set; }

        public Etterem() {
            Menu = new List<Menuelem>();
            Rendelesek = new List<Rendeles>();
        }

        public void HozzaadMenu(Menuelem menuelem) {
            Menu.Add(menuelem);
            System.Console.WriteLine($"{menuelem.nev} hozzáadva a menühöz.");
        }

        public void ListazMenut() {
            System.Console.WriteLine("Menü:");
            foreach (var menuelem in Menu) {
                System.Console.WriteLine(menuelem.ToString());
            }
        }

        public void UjRendeles(Vendeg vendeg) {
            Rendeles rendeles = new Rendeles(vendeg, new List<Menuelem>(vendeg.rendelesek));
            Rendelesek.Add(rendeles);

            System.Console.WriteLine($"{vendeg.nev} új rendelést adott le.");
            System.Console.WriteLine(rendeles.ToString());
        }
    }
}