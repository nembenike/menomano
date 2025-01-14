namespace Feladat {
  class Program {
    static void Main() {
      Ember emberke = new Ember("Ágó", 17);

      emberke.Nev = "Sigma";

      System.Console.WriteLine(emberke.Nev);
      System.Console.WriteLine(emberke);
      emberke.koszon();

      Console.WriteLine("Add meg a neved!");
      emberke.Nev = Console.ReadLine();
      Console.WriteLine("Add meg a korod!");
      emberke.Kor = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine(emberke);
      emberke.koszon();
    }
  } 
}
