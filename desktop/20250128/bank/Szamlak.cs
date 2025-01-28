namespace Feladatok
{
  internal class BankSzamla
  {
    // Class attributes
    private static int kovetkezo_szamlaszam = 1000;
    public string szamlaszam { get; private set; }
    public string tulajdonosnev { get; private set; }
    public int egyenleg { get; private set; }

    // Constructors to initialize the values
    public BankSzamla(string tulajdonos_nev, int kezdoegyenleg)
    {
      szamlaszam = $"ACC{kovetkezo_szamlaszam++}";
      tulajdonosnev = tulajdonos_nev;
      egyenleg = kezdoegyenleg;
    }

    // Deposit method
    public void befizet(int osszeg)
    {
      if (osszeg > 0)
      {
        egyenleg += osszeg;
        System.Console.WriteLine("befizetted a pezt");
      }
      else
      {
        System.Console.WriteLine("valamit elbasztalxdd");
      }
    }

    public void withdraw(int osszeg)
    {
      if (egyenleg - osszeg < 0 && osszeg > 0)
      {
        System.Console.WriteLine("Nincs eleg penzed vagy nem attal meg rendes osszeget");
      }
      else
      {
        egyenleg -= osszeg;
        System.Console.WriteLine("Kivetted a pezt");
      }
    }

    public string lekerdezes()
    {
      return $"Szamlaszam: {szamlaszam} Tulajdonos: {tulajdonosnev} Egyenleg: {egyenleg}";
    }
  }
}
