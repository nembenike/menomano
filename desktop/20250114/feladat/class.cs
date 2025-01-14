using System.Numerics;

namespace Feladat {
  internal class Pont {
    // Variables
    private int X, Y;
    private string Name;
    Random rng = new Random();

    // Getters and Setters
    public int x {
      get { return X; }
      set { X = value; }
    }

    public int y {
      get { return Y; }
      set { y = value; }
    }

    public string name {
      get { return Name; }
      set { Name = value; }
    }

    // Constructors
    public Pont(int x, int y, string name) {
      this.X = x;
      this.Y = y;
      this.Name = name;
    }

    public Pont(string Name) {
      this.X = 6;
      this.Y = 9;
      this.Name = "Koordináta";
    }

    public Pont(Vector2 vector) {
      this.X = rng.Next((int)vector.X, (int)vector.Y + 1); 
      this.Y = rng.Next((int)vector.X, (int)vector.Y + 1);
      this.Name = "Random koordináta";
    }

    public static double getDistance(Pont P, Pont Q) {
      double d;
      d = Math.Sqrt(Math.Pow((P.X-P.Y),2)+Math.Pow((Q.X-Q.Y), 2));
      return d;
    }

    public void swapPoints() {
      int temp;
      temp = x;
      x = y;
      y = temp;
      Console.WriteLine($"The point coordinates have been switched\n New coordinates X: {X}, Y: {Y}");
    }

    public void enlargePoint(int multiplier) {
      x *= multiplier;
      y *= multiplier;
      Console.WriteLine($"Point has been enlarged\n New Coordinates X: {X} Y: {Y}");
    }

    public bool isOrigin(Pont point) {
      return X == 0 && Y == 0;
    }

    public override string ToString() {
       return $"X: {X} Y: {Y} Name: {Name}";
    }
  }
}
