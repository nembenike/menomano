namespace iskola {
  class Diak {
    public string nev { get; set; }
    public string osztaly { get; set; }
    public int azonosito { get; set; }

    public Diak(string nev, string osztaly, int azonosito) {
      this.nev = nev;
      this.osztaly = osztaly;
      this.azonosito = azonosito;
    }

    public void TeljesNevKiirasa() {
      System.Console.WriteLine($"{nev} {osztaly}");
    }
  }
}
