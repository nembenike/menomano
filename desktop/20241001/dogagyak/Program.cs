/*
2024.10.01 ASZTALI ALKALMAZÁS FEJLESZTÉS ÓRA
Írta: Berényi Bence 10.D
Budapesti Műszaki SzC Petrik Lajos kéttanításinyelvű technikum tanulója

Olvasás előtt ajánlott tudni hogy nem egy CASUAL programmer vagyok,
hanem tryhard dev ezért tudok néhány C# syntactic sugart ezért lehet van olyan
data structure vagy egyéb más használva amit nem vettünk.
*/

class Program
{
    static char[] seats = new char[10];
    static int bookedCount = 0;
    static int canceledCount = 0;

    static void Main(string[] args)
    {
        for (int i = 0; i < seats.Length; i++)
        {
            seats[i] = (char)(i + '1');
        }

        while (true)
        {
            Console.WriteLine("\n---- Mozi Jegyfoglalás ----");
            Console.WriteLine("1. Jegy foglalása");
            Console.WriteLine("2. Elérhető helyek megtekintése");
            Console.WriteLine("3. Foglalás visszamondása");
            Console.WriteLine("4. Kilépés");
            Console.Write("Válassz egy lehetőséget: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BookSeat();
                    break;
                case "2":
                    DisplayAvailableSeats();
                    break;
                case "3":
                    CancelBooking();
                    break;
                case "4":
                    ShowSummaryAndExit();
                    return;
                default:
                    Console.WriteLine("Érvénytelen választás! Kérlek, válassz egy számot 1-4 között.");
                    break;
            }
        }
    }

    static void BookSeat()
    {
        Console.Write("Add meg a foglalni kívánt hely számát (1-10): ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int seatNumber) && seatNumber >= 1 && seatNumber <= 10)
        {
            if (seats[seatNumber - 1] == 'X')
            {
                Console.WriteLine("A hely már foglalt! Kérlek, válassz egy másik helyet.");
            }
            else
            {
                seats[seatNumber - 1] = 'X';
                bookedCount++;
                Console.WriteLine($"Sikeresen lefoglaltad a(z) {seatNumber}. helyet.");
            }
        }
        else
        {
            Console.WriteLine("Érvénytelen helyszám! Kérlek, adj meg egy számot 1-10 között.");
        }
    }

    static void DisplayAvailableSeats()
    {
        Console.WriteLine("Elérhető helyek:");
        for (int i = 0; i < seats.Length; i++)
        {
            Console.Write(seats[i] + " ");
        }
        Console.WriteLine();
    }

    static void CancelBooking()
    {
        Console.Write("Add meg a visszamondani kívánt hely számát (1-10): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int seatNumber) && seatNumber >= 1 && seatNumber <= 10)
        {
            if (seats[seatNumber - 1] == 'X')
            {
                seats[seatNumber - 1] = (char)(seatNumber + '0');
                canceledCount++;
                Console.WriteLine($"Sikeresen visszamondtad a(z) {seatNumber}. helyet.");
            }
            else
            {
                Console.WriteLine("A hely nem foglalt! Nincs mit visszamondani.");
            }
        }
        else
        {
            Console.WriteLine("Érvénytelen helyszám! Kérlek, adj meg egy számot 1-10 között.");
        }
    }

    static void ShowSummaryAndExit()
    {
        Console.WriteLine($"Összes foglalás: {bookedCount}, Összes visszamondás: {canceledCount}");
        Console.WriteLine("KÖSZÖNJÜK HOGY HASZNÁLTA AZ IGAZÁBOL NEM MŰKÖDŐ JEGYRENDSZERT!!!4!!!!");
    }
}
