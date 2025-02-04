namespace OOPalapok {
  using System.Collections.Generic;

  internal class Emberek {
    public List<Ember> lista { get; set; }

    public Emberek(int db) {
      lista = new List<Ember>(db);
    }

    public override string ToString() {
      var result = "Magasság (cm) | Súly (kg) | TTI | Testalkat\n";
      result += "---------------------------------------------\n";
      foreach (var ember in lista) {
        string testalkat = ember.NormalTTI() ? "normál" : "túlsúlyos";
        result += $"{ember.TestMagassag} | {ember.TestSuly:F1} | {ember.TestTomegIndex()} | {testalkat}\n";
      }
      return result;
    }

    public double AtlagosTestSuly() {
      double totalSuly = 0;
      foreach (var ember in lista) {
        totalSuly += ember.TestSuly;
      }
      return totalSuly / lista.Count;
    }
  }
} 