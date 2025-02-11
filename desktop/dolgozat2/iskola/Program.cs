namespace iskola {
  class Program {
    static void Main(string[] args) {
      Diak diak = new Diak("Berényi Bence", "11D", 1);
      Tantargy tantargy = new Tantargy("Asztali alkalmazás fejlesztés", 5);
      Tanar tanar = new Tanar("Merényi tanárúr", 101);

      Osztaly osztaly = new Osztaly("11D", tanar);
      osztaly.HozzaadDiak(diak);

      Ertekeles ertekeles = new Ertekeles(diak, tantargy, 5);
      
      diak.TeljesNevKiirasa();
      tantargy.TantargyAdatok();
      osztaly.OsszesDiakListazasa();
      osztaly.OsztalyfonokKiirasa();
      ertekeles.JegyKiirasa();
    }
  }
}
