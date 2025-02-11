namespace iskola {
  class Ertekeles {
    public Diak diak { get; set; }
    public Tantargy tantargy { get; set; }
    public int erdemjegy { get; set; }

    public Ertekeles(Diak diak, Tantargy tantargy, int erdemjegy) {
      this.diak = diak;
      this.tantargy = tantargy;
      this.erdemjegy = erdemjegy;
    }

    public void JegyKiirasa() {
      System.Console.WriteLine($"{diak.nev} kapott {tantargy.nev}bol {erdemjegy} jegyet");
    }
  }
}
