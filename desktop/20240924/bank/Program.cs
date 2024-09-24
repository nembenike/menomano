using System;

class Program
{
  static int balance, dailyWithdraw, dailyWithdrawLimit;
  static string pin;

  static void Main()
  {
    balance = 100000;
    dailyWithdraw = 0;
    dailyWithdrawLimit = 100000;
    pin = "124533";
    Authenticate();
    StartMenu();
  }

  static void Authenticate()
  {
    int failCount = 0;
    while (true)
    {
      if (failCount == 3)
      {
        Console.WriteLine("Failed to enter correct PIN 3 times! Account locked :<");
        Environment.Exit(0);
      }
      if (failCount > 0)
        Console.WriteLine("Wrong PIN, please try again:");
      else
        Console.WriteLine("Please enter your PIN:");
      if (Console.ReadLine() == pin) break;
      failCount++;
    }
    Console.WriteLine("Successful login!");
  }

  static void StartMenu()
  {
    while (true)
    {
      Console.WriteLine("\nCommands:\n\t- bal: get the balance.\n\t- wdraw: Withraw money.\n\t- dep: Deposit money into the account.\n\t- quit: Quit the program.");
      Console.Write("> ");
      string input = "";
      try { input = Console.ReadLine(); }
      catch { Environment.Exit(1); }
      switch (input)
      {
        case "dep": Deposit(); break;
        case "bal": Console.WriteLine($"Balance: {balance}Ft"); break;
        case "wdraw": Withdraw(); break;
        case "quit": Console.WriteLine("Quitting!"); Environment.Exit(0); break;
        default: Console.WriteLine("Wrong input: Try again!"); break;
      }
    }
  }

  static void Deposit()
  {
    Console.WriteLine("How much do you wish to deposit? [type `0` to terminate]");
    while (true)
    {
      int amount = Convert.ToInt32(Console.ReadLine());
      if (amount == 0) break;
      else if (amount < 0)
        Console.WriteLine("Deposited amount cannot be negative!");
      else
      {
        int prevBalance = balance;
        balance += amount;
        Console.WriteLine($"Money deposited: bal ${prevBalance} -> {balance}Ft");
        break;
      }
    }
  }

  static void Withdraw()
  {
    Console.WriteLine("How much do you wish to withdraw from your account? [type `0` to terminate]");
    while (true)
    {
      int amount = Convert.ToInt32(Console.ReadLine());
      if (amount > balance)
        Console.WriteLine($"Cannot withdraw more than your current balance!\n\t- Balance: {balance}Ft");
      else if (amount == 0)
        break;
      else if (amount < 0)
        Console.WriteLine("Withdraw amount cannot be negative!");
      else
      {
        int totalWithdraw = dailyWithdraw + amount;
        if (totalWithdraw > dailyWithdrawLimit)
        {
          Console.WriteLine($"Transaction would exceed daily withdraw limit of {dailyWithdrawLimit}Ft");
          continue;
        }
        dailyWithdraw += amount;
        int prevBalance = balance;
        balance -= amount;
        Console.WriteLine($"Money taken: bal {prevBalance}Ft -> {balance}Ft");
        break;
      }
    }
  }
}
