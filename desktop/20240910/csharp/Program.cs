// Epic for loops

// Just an epic for loop
for (int i = 0; i <= 10; i++)
{
  Console.WriteLine(i);
}

// Epic forloop but backwards
for (int i = 10; i >= 0; i--)
{
  Console.WriteLine(i);
}

// Epic forloop but 2 at a time
for (int i = 0; i <= 10; i += 2)
{
  Console.WriteLine(i);
}

// Array
char[] letters = { 'a', 'b', 'c', 'd' };

// foreach
foreach (char letter in letters)
{
  Console.WriteLine(letter);
}

// lengh of array
Console.WriteLine(letters.Length);

// strings are arrays of chars duh
string s = "Hello World!";
Console.WriteLine(s[3]);

// Flow control
if (true)
{
  Console.WriteLine("The flow is being controlled");
}
else // this will never run but it's here for the sake of the example
{
  Console.WriteLine("The flow is not being controlled");
}

// read from console
Console.WriteLine("Enter a number: ");
int n = Convert.ToInt32(Console.ReadLine());

// ternary operator example
int num = 32;
Console.WriteLine(num % 2 == 0 ? "Even" : "Odd");

// switch case

Console.WriteLine("Enter a number: ");
int number = Convert.ToInt32(Console.ReadLine());

switch (number)
{
  case 10:
    Console.WriteLine("10");
    break;
  case 20:
    Console.WriteLine("20");
    break;
  case 30:
    Console.WriteLine("30");
    break;
  default:
    Console.WriteLine("Not 10, 20 or 30");
    break;
}
