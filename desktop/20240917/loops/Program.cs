static void firstTask()
{
  int guess, final;
  Random rand = new Random();
  Console.WriteLine("Give a guess: ");
  guess = Convert.ToInt32(Console.ReadLine());

  while (guess != 0 && guess != 1)
  {
    Console.WriteLine("Invalid guess\nGive your guess (0: heads, 1: tails)");
    guess = Convert.ToInt32(Console.ReadLine());
  }

  final = rand.Next(0, 2);

  if (final == guess)
  {
    Console.WriteLine("Amazing, you have won.");
  }
  else
  {
    Console.WriteLine("How terrible! You have lost...");
  }
  Console.ReadLine();
}

static void secondTask()
{
  Console.WriteLine("Give a number between 1 and a 100");
  int num = Convert.ToInt32(Console.ReadLine());

  while (num < 1 || num > 100)
  {
    Console.WriteLine("Invalid number, give one between 1 and 100.");
    num = Convert.ToInt32(Console.ReadLine());
  }

  string[] ones = { "", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };
  string[] tens = { "", "tíz", "húsz", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };

  if (num % 10 == 0)
  {
    Console.WriteLine(tens[num / 10]);
  }
  else
  {
    Console.WriteLine($"{tens[num / 10]} {(num > 10 ? " " : "")} {ones[num % 10]}");
  }
}

static void sixthTask()
{
  int a, b, stepsize;
  Console.WriteLine("Give two numbers:");
  a = Convert.ToInt32(Console.ReadLine());
  b = Convert.ToInt32(Console.ReadLine());

  Console.WriteLine("Give a stepsize:");
  stepsize = Convert.ToInt32(Console.ReadLine());

  if (a > b)
  {
    while (a >= b)
    {
      Console.WriteLine(a);
      a -= stepsize;
    }
  }
  else
  {
    while (a <= b)
    {
      Console.WriteLine(a);
      a += stepsize;
    }
  }
}

firstTask();
secondTask();
sixthTask();







