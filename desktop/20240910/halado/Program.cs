// Prime number search

Console.WriteLine("Enter a number to check if it is prime: ");
int number = int.Parse(Console.ReadLine());

for (int i = 2; i < number; i++)
{
  if (number % i == 0)
  {
    Console.WriteLine("The number is not prime.");
    break;
  }
  else
  {
    Console.WriteLine("The number is prime.");
    break;
  }
}

// Removing duplicates from an array

int[] numbers = { 1, 2, 3, 4, 3, 6, 2, 8, 9, 10 };

HashSet<int> uniqueNumbers = new HashSet<int>(numbers);

int[] uniqueArray = uniqueNumbers.ToArray();

Console.WriteLine("Array with duplicates removed:");
foreach (int num in uniqueArray)
{
  Console.WriteLine(num);
}

// Two biggest numbers in an array
// ez amugy egy nagyon vicces megoldas
int max = numbers.Max();
numbers = numbers.Where(val => val != max).ToArray();
int max2 = numbers.Max();
Console.WriteLine("The two biggest numbers are: " + max + " and " + max2);

// Fibonacci sequence
// ez nagyon szep recursive van megcsinalva
for (int i = 0; i < 10; i++)
{
  Console.WriteLine(Fibonacci(i));
}

static long Fibonacci(int n)
{
  if (n <= 1) return n;
  return Fibonacci(n - 1) + Fibonacci(n - 2);
}

// Reverse string

char[] charArray = "helloworld".ToCharArray();
Console.WriteLine(charArray.Reverse());

// Count vowels and consonants in a string

char[] vowels = "aeiou".ToCharArray();
char[] consonants = "bcdfghjklmnpqrstvwxyz".ToCharArray();

for (int i = 0; i < charArray.Length; i++)
{
  if (vowels.Contains(charArray[i]))
  {
    Console.WriteLine("Vowel: " + charArray[i]);
  }
  else if (consonants.Contains(charArray[i]))
  {
    Console.WriteLine("Consonant: " + charArray[i]);
  }
}

// Most common element in an array
// ez valami c# specific dolog
var mostOccurredNum = numbers
  .GroupBy(num => num)
  .OrderByDescending(g => g.Count())
  .First();

Console.WriteLine($"Number: {mostOccurredNum.Key} Count: {mostOccurredNum.Count()}");

