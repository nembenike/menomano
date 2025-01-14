using System.Numerics;

namespace Feladat {
  internal class Pont {
    // Variables
    private int X, Y;
    private string Name;

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
      Random rng = new Random();
      this.X = rng.Next(0, (int)vector.X + 1); 
      this.Y = rng.Next(0, (int)vector.Y + 1);
      this.Name = "Random koordináta";
    }

    public override string ToString() {
      return $"X: {X} Y: {Y} Name: {Name}";
    }
  }
}
