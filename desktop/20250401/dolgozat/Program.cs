namespace Etterem
{
    class Program
    {
        static void Main(string[] args)
        {
            Etterem etterem = new Etterem();
            etterem.Menu = Fajlkezelo.MenuBetoltese();

            Vendeg vendeg1 = new Vendeg("Kiss Péter");

            Menuelem burger = new Menuelem("Sajtburger", 1500, "Étel");
            Menuelem cola = new Menuelem("Kóla", 500, "Ital");

            etterem.HozzaadMenu(burger);
            etterem.HozzaadMenu(cola);

            etterem.ListazMenut();

            vendeg1.Rendel(burger);
            vendeg1.Rendel(cola);

            etterem.UjRendeles(vendeg1);

            Fajlkezelo.MenuMentese(etterem.Menu);
            Fajlkezelo.RendelesMentese(etterem.Rendelesek);

        }
    }
}