namespace OOPalapok {
  class Program {
    static void Main(string[] args) {
      Ember ember1 = new Ember(70.5, 175);
      Console.WriteLine(ember1.ToString());
      Console.WriteLine($"TTI: {ember1.TestTomegIndex()}");
      Console.WriteLine($"Normál TTI: {ember1.NormalTTI()}");
    }
  }
}
