namespace Feladat {
  internal class Ember {
    // ToString

    // Public, Private or Protected fields
    private int kor;
    private string nev;

    /*
    private int Kor;
    private string Nev;
    */

    // Getter
    public int Kor {
      get { return kor; }
      set { kor = value; }
    }

    public string Nev {
      get { return nev; }
      set { nev = value; }
    }

    // Constructor
    public Ember(string nev, int kor) {
      this.nev = nev;
      this.kor = kor;
      /*
      Nev = nev;
      Kor = kor;
      */
    }


    public override string ToString() {
      return $"Név: {nev}, Kor: {kor}";
    }
    public void koszon() {
      System.Console.WriteLine($"Üdvözöllek, {nev}!");
    }
  }
}
