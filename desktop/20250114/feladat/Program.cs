using System.Numerics;

namespace Feladat {
  class Program {
    static void Main(string[] args) {
      Pont pont1 = new Pont(10, 10, "Koordináta");
      Pont pont2 = new Pont("Koordináta2");

      Console.WriteLine(pont1);
      Console.WriteLine(pont2);

      Console.WriteLine("Add meg az intervallum első felét:");
      int first = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Add meg az intervallum második felét");
      int second = Convert.ToInt32(Console.ReadLine());

      Vector2 vector = new Vector2(first, second);

      Pont pont3 = new Pont(vector);
      Console.WriteLine(pont3);

    }
  }
}
