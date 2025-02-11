namespace iskola {
  class Osztaly {
    public string nev { get; set; }
    public List<Diak> diakok { get; set; }
    public Tanar osztalyfonok { get; set; }

    public Osztaly(string nev, Tanar osztalyfonok) {
      this.nev = nev;
      this.diakok = new List<Diak>();
      this.osztalyfonok = osztalyfonok;
    }

    public void HozzaadDiak(Diak diak) {
      if (diakok.Count >= 25) {
        System.Console.WriteLine("Tul sok diak van az osztalyban");
      } else {
        diakok.Add(diak);
        System.Console.WriteLine("Diak hozzaadva");
      }
    }

    public void OsszesDiakListazasa() {
      foreach (var item in diakok) {
        System.Console.WriteLine(item.nev);
      }
    }

    public void OsztalyfonokKiirasa() {
      System.Console.WriteLine(osztalyfonok.nev);
    }
  }
}
