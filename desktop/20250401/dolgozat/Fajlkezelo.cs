using System.IO;

namespace Etterem {
    class Fajlkezelo {
        private const string MenuFile = "menu.txt";
        private const string RendelesekFile = "rendelesek.txt";

        public static List<Menuelem> MenuBetoltese() {
            List<Menuelem> menu = new List<Menuelem>();
            if (File.Exists(MenuFile)) {
                var lines = File.ReadAllLines(MenuFile);
                foreach (var line in lines) {
                    var parts = line.Split(';');
                    if (parts.Length == 3) {
                        string nev = parts[0];
                        int ar = int.Parse(parts[1]);
                        string kategoria = parts[2];
                        menu.Add(new Menuelem(nev, ar, kategoria));
                    }
                }
            }
            return menu;
        }

        public static void MenuMentese(List<Menuelem> menu) {
            using (StreamWriter writer = new StreamWriter(MenuFile)) {
                foreach (var menuelem in menu) {
                    writer.WriteLine(menuelem.ToCSV());
                }
            }
        }

        public static void RendelesMentese(List<Rendeles> rendelesek) {
            using (StreamWriter writer = new StreamWriter(RendelesekFile)) {
                foreach (var rendeles in rendelesek) {
                    writer.WriteLine(rendeles.ToString());
                }
            }
        }
    }
}