namespace iskola {
  class Tantargy {
    public string nev { get; set; }
    public int kontaktorak { get; set; }

    public Tantargy(string nev, int kontaktorak) {
      this.nev = nev;
      this.kontaktorak = kontaktorak;
    }

    public void TantargyAdatok() {
      System.Console.WriteLine($"{nev} {kontaktorak}");
    }
  }
}
