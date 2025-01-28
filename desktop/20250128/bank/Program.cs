namespace Feladatok
{
  class Program
  {
    static void Main(string[] args)
    {
      Bank bank = new Bank();
      bool running = true;

      while (running)
      {
        Console.WriteLine("\n=== Bank Menu ===");
        Console.WriteLine("1. Create new account");
        Console.WriteLine("2. Search account");
        Console.WriteLine("3. List all accounts");
        Console.WriteLine("4. Deposit money");
        Console.WriteLine("5. Withdraw money");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option (1-6): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
          case "1":
            Console.Write("Enter account owner name: ");
            string name = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            if (int.TryParse(Console.ReadLine(), out int balance))
            {
              bank.create_account(name, balance);
            }
            else
            {
              Console.WriteLine("Invalid balance amount!");
            }
            break;

          case "2":
            Console.Write("Enter account number: ");
            string accNum = Console.ReadLine();
            BankSzamla account = bank.search(accNum);
            if (account != null)
            {
              Console.WriteLine(account.lekerdezes());
            }
            else
            {
              Console.WriteLine("Account not found!");
            }
            break;

          case "3":
            bank.all_accounts();
            break;

          case "4":
            Console.Write("Enter account number: ");
            string depAccNum = Console.ReadLine();
            BankSzamla depAccount = bank.search(depAccNum);
            if (depAccount != null)
            {
              Console.Write("Enter amount to deposit: ");
              if (int.TryParse(Console.ReadLine(), out int amount))
              {
                depAccount.befizet(amount);
              }
              else
              {
                Console.WriteLine("Invalid amount!");
              }
            }
            else
            {
              Console.WriteLine("Account not found!");
            }
            break;

          case "5":
            Console.Write("Enter account number: ");
            string withAccNum = Console.ReadLine();
            BankSzamla withAccount = bank.search(withAccNum);
            if (withAccount != null)
            {
              Console.Write("Enter amount to withdraw: ");
              if (int.TryParse(Console.ReadLine(), out int amount))
              {
                withAccount.withdraw(amount);
              }
              else
              {
                Console.WriteLine("Invalid amount!");
              }
            }
            else
            {
              Console.WriteLine("Account not found!");
            }
            break;

          case "6":
            running = false;
            Console.WriteLine("Goodbye!");
            break;

          default:
            Console.WriteLine("Invalid option! Please choose 1-6.");
            break;
        }
      }
    }
  }
}
