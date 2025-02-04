namespace OOPalapok {
  class Program {
    static void Main(string[] args) {
      Emberek emberek = new Emberek(3);

      emberek.lista.Add(new Ember(70.5, 175));
      emberek.lista.Add(new Ember(63.3, 160));
      emberek.lista.Add(new Ember(87.4, 158));

      Console.WriteLine(emberek.ToString());

      Console.WriteLine($"Átlagos testsúly: {emberek.AtlagosTestSuly():F1} kg");
    }
  }
}
