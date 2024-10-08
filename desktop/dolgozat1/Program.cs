/*
2024.10.08
Asztali alkalmazás fejlesztése dolgozat
Berényi Bence 11.D

PS:
Tömb implementation

int[] parking_spots = new int[10];

tomb feltoltheto 1-10ig es index alapjan kezelhetjuk a helyeket
kb ugyanezek a methodok csak index alapjan es neha forloop
*/

const int available_spaces = 10;
int used_spaces = 0;

int total_parked_cars = 0;
int total_exited_cars = 0;

Console.WriteLine("Welcome to our amazing parking system!");
Console.WriteLine("Choose an option to get started:");

void park()
{
  if (used_spaces >= available_spaces)
  {
    Console.WriteLine("Unfortunately the parking lot is full.");
    Console.WriteLine("Please try again later.");
    return;
  }
  used_spaces++;
  total_parked_cars++;
  Console.WriteLine("You successfully parked in the lot!");
}

void exit_park()
{
  if (used_spaces <= 0)
  {
    Console.WriteLine("You are not parked DUMMY. Go park and then you can exit parking.");
    return;
  }
  used_spaces--;
  total_exited_cars++;
  Console.WriteLine("You were able to exit the parking lot, good job.");
}

void check_available_spaces()
{
  Console.WriteLine($"There are currently {available_spaces - used_spaces} spaces left.");
}

void check_cars_in_lot()
{
  Console.WriteLine($"There are currently {used_spaces} cars in the lot right now.");
}

void exit_program()
{
  Console.WriteLine($"There were {total_parked_cars} cars parked in total.");
  Console.WriteLine($"There were {total_exited_cars} cars exited in total.");
  Environment.Exit(0);
}

while (true)
{
  Console.WriteLine("1. Park");
  Console.WriteLine("2. Exit parking");
  Console.WriteLine("3. Check available parking spots");
  Console.WriteLine("4. Check cars currently parking");
  Console.WriteLine("5. Exit the program");

  string? input_buffer = Console.ReadLine();

  switch (input_buffer)
  {
    case "1":
      park();
      break;

    case "2":
      exit_park();
      break;

    case "3":
      check_available_spaces();
      break;

    case "4":
      check_cars_in_lot();
      break;

    case "5":
      exit_program();
      break;

    default:
      Console.WriteLine("Please choose a valid option.");
      break;
  }
}
