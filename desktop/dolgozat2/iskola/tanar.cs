namespace iskola {
  class Tanar {
    public string nev { get; set; }
    public List<Tantargy> tantargyak { get; set; }
    public int tanarid { get; set; }

    public Tanar(string nev, int tanarid) {
      this.nev = nev;
      this.tanarid = tanarid;
      this.tantargyak = new List<Tantargy>();
    }

    public void HozzaadTantargy(Tantargy ujtargy) {
      tantargyak.Add(ujtargy);
      System.Console.WriteLine("Tantargy hozzadva");
    }

    public void OktatottTantargyak() {
      System.Console.WriteLine($"{nev} oktatja a kovetkezo tantargyakat:");
      foreach (Tantargy item in tantargyak) {
        System.Console.WriteLine(item.nev);
      }
    }
  }
}
