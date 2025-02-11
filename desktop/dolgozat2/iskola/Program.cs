namespace iskola {
  class Program {
    static void Main(string[] args) {
      Diak diak = new Diak("Berényi Bence", "11D", 1);
      Diak diak2 = new Diak("Garay Ágoston", "11D", 2);
      Diak diak3 = new Diak("Bóta Milán", "11D", 3);
      Tantargy tantargy = new Tantargy("Asztali alkalmazás fejlesztés", 5);
      Tanar tanar = new Tanar("Merényi tanárúr", 101);

      Tanar osztalyfonok = new Tanar("Tóth Éva", 101);
      Osztaly osztaly = new Osztaly("11D", osztalyfonok);

      osztaly.HozzaadDiak(diak);
      osztaly.HozzaadDiak(diak2);
      osztaly.HozzaadDiak(diak3);

      Ertekeles ertekeles = new Ertekeles(diak, tantargy, 5);
      Ertekeles ertekeles2 = new Ertekeles(diak2, tantargy, 4);
      Ertekeles ertekeles3 = new Ertekeles(diak3, tantargy, 3);
      

      diak.TeljesNevKiirasa();
      diak2.TeljesNevKiirasa();
      diak3.TeljesNevKiirasa();

      tantargy.TantargyAdatok();

      osztaly.OsszesDiakListazasa();
      osztaly.OsztalyfonokKiirasa();

      ertekeles.JegyKiirasa();
      ertekeles2.JegyKiirasa();
      ertekeles3.JegyKiirasa();

      tanar.HozzaadTantargy(tantargy);
      tanar.OktatottTantargyak();
    }
  }
}
