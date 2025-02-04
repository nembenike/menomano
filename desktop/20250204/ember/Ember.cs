namespace OOPalapok {
  internal class Ember {
    private double testSuly { get; set; }
    private int testMagassag { get; set; }

    public Ember(double testSuly, int testMagassag) {
      this.testSuly = testSuly;
      this.testMagassag = testMagassag;
    }

    public override string ToString() {
      return $"Magasság: {testMagassag} cm, Súly: {testSuly:F1} kg";
    }

    public double TestTomegIndex() {
      double magassagM = testMagassag / 100.0;
      return Math.Round(testSuly / Math.Pow(magassagM, 2), 2);
    }

    public bool NormalTTI() {
      double tti = TestTomegIndex();
      return tti >= 18.5 && tti < 25;
    }

    public double TestSuly => testSuly;
    public int TestMagassag => testMagassag;
  }
}
