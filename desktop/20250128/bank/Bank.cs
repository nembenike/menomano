namespace Feladatok
{
  internal class Bank
  {
    // Attributes
    private List<BankSzamla> bankszamlak = new List<BankSzamla>();

    // New számla
    public void create_account(string tulajdonos_nev, int kezdo_egyenleg)
    {
      BankSzamla uj_szamla = new BankSzamla(tulajdonos_nev, kezdo_egyenleg);
      bankszamlak.Add(uj_szamla);
      System.Console.WriteLine($"uj szamla kesz :D {uj_szamla.lekerdezes()}");
    }

    public BankSzamla search(string szamla_szam)
    {
      foreach (var bankszamla in bankszamlak)
      {
        if (bankszamla.szamlaszam == szamla_szam)
        {
          return bankszamla;
        }
      }
      return null;
    }

    public void all_accounts()
    {
      if (bankszamlak.Count == 0)
      {
        System.Console.WriteLine("Nincs egy szamla sem");
      }
      else
      {
        foreach (var bankszamla in bankszamlak)
        {
          Console.WriteLine(bankszamla.lekerdezes());
        }
      }
    }
  }
}
