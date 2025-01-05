class ChristmasGiftPlanner
{
    class Gift
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }

    private static List<Gift> gifts = new List<Gift>();
    private static int budget;

    static void Main()
    {
        Console.WriteLine("Halihó, ez a KAP (Karácsonyi Ajándéktervező Program)!");
        SetBudget();
        Menu();
    }

    static void SetBudget()
    {
        while (true)
        {
            Console.Write("Add meg az ajándékozási költségvetésedet (Ft): ");
            if (int.TryParse(Console.ReadLine(), out budget) && budget > 0)
                break;
            Console.WriteLine("A költségvetésnek pozitív számnak kell lennie!");
        }
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\nVálassz egy lehetőséget:");
            Console.WriteLine("1. Ajándék hozzáadása");
            Console.WriteLine("2. Ajándék szerkesztése");
            Console.WriteLine("3. Ajándék eltávolítása");
            Console.WriteLine("4. Ajándékok megtekintése");
            Console.WriteLine("5. Statisztikák megtekintése");
            Console.WriteLine("6. Ajándékok kategorizálása");
            Console.WriteLine("7. Kilépés");

            switch (Console.ReadLine())
            {
                case "1": AddGift(); break;
                case "2": EditGift(); break;
                case "3": RemoveGift(); break;
                case "4": ViewGifts(); break;
                case "5": ShowStatistics(); break;
                case "6": CategorizeGifts(); break;
                case "7":
                    Console.WriteLine("Kellemes karácsonyt! 🎄");
                    return;
                default:
                    Console.WriteLine("Érvénytelen választás! Próbáld újra.");
                    break;
            }
        }
    }

    static void AddGift()
    {
        Console.Write("Ajándék neve: ");
        string name = Console.ReadLine();
        Console.Write("Ajándék ára (Ft): ");
        if (!int.TryParse(Console.ReadLine(), out int price) || price <= 0)
        {
            Console.WriteLine("Az árnak pozitív számnak kell lennie!");
            return;
        }
        Console.Write("Ajándék kategóriája: ");
        string category = Console.ReadLine();

        gifts.Add(new Gift { Name = name, Price = price, Category = category });
        Console.WriteLine("Ajándék hozzáadva!");
    }

    static void EditGift()
    {
        ViewGifts();
        Console.Write("Melyik ajándékot szeretnéd szerkeszteni? (Írd be a számát): ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gifts.Count)
        {
            var gift = gifts[index - 1];
            Console.WriteLine($"Szerkeszted: {gift.Name} ({gift.Price} Ft, {gift.Category})");
            Console.Write("Új név (hagy üresen, ha nem változik): ");
            string newName = Console.ReadLine();
            Console.Write("Új ár (Ft): ");
            if (int.TryParse(Console.ReadLine(), out int newPrice) && newPrice > 0)
                gift.Price = newPrice;
            Console.Write("Új kategória (hagy üresen, ha nem változik): ");
            string newCategory = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName)) gift.Name = newName;
            if (!string.IsNullOrWhiteSpace(newCategory)) gift.Category = newCategory;

            Console.WriteLine("Ajándék frissítve!");
        }
        else
        {
            Console.WriteLine("Érvénytelen választás!");
        }
    }

    static void RemoveGift()
    {
        ViewGifts();
        Console.Write("Melyik ajándékot szeretnéd törölni? (Írd be a számát): ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gifts.Count)
        {
            gifts.RemoveAt(index - 1);
            Console.WriteLine("Ajándék törölve!");
        }
        else
        {
            Console.WriteLine("Érvénytelen választás!");
        }
    }

    static void ViewGifts()
    {
        if (!gifts.Any())
        {
            Console.WriteLine("Nincs még ajándék a listában.");
            return;
        }

        Console.WriteLine("Ajándékok listája:");
        for (int i = 0; i < gifts.Count; i++)
        {
            var gift = gifts[i];
            Console.WriteLine($"{i + 1}. {gift.Name} - {gift.Price} Ft ({gift.Category})");
        }
    }

    static void ShowStatistics()
    {
        if (!gifts.Any())
        {
            Console.WriteLine("Nincs statisztika, mivel még nincs ajándék a listában.");
            return;
        }

        int totalCost = gifts.Sum(g => g.Price);
        var mostExpensive = gifts.OrderByDescending(g => g.Price).First();
        var cheapest = gifts.OrderBy(g => g.Price).First();

        Console.WriteLine($"Eddig elköltött összeg: {totalCost} Ft");
        Console.WriteLine($"Hátralévő költségvetés: {budget - totalCost} Ft");
        Console.WriteLine($"Legdrágább ajándék: {mostExpensive.Name} ({mostExpensive.Price} Ft)");
        Console.WriteLine($"Legolcsóbb ajándék: {cheapest.Name} ({cheapest.Price} Ft)");
    }

    static void CategorizeGifts()
    {
        if (!gifts.Any())
        {
            Console.WriteLine("Nincs még ajándék a listában.");
            return;
        }

        var categories = gifts.GroupBy(g => g.Category);
        foreach (var category in categories)
        {
            Console.WriteLine($"\n{category.Key} kategória:");
            foreach (var gift in category)
            {
                Console.WriteLine($"- {gift.Name} ({gift.Price} Ft)");
            }
        }
    }
}
