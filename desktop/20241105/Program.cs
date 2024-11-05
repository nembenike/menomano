/*
Desktop Application Development Class
2024.11.05
Berenyi Bence 11.D
*/

static bool IsPrime(int number)
{
  if (number <= 1) return false;
  if (number == 2 || number == 3) return true;
  if (number % 2 == 0 || number % 3 == 0) return false;

  for (int i = 5; i * i <= number; i += 6)
  {
    if (number % i == 0 || number % (i + 2) == 0) return false;
  }
  return true;
}

static List<int> PrimeNumbers(int start, int end)
{
  List<int> primeList = new List<int>();

  for (int i = start; i < end; i++)
    if (IsPrime(i))
    {
      primeList.Add(i);
    }
  return primeList;
}

Console.WriteLine(string.Join(", ", PrimeNumbers(1, 100)));
