using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace NewBankOfSuncoast
{
  class Program
  {
    static void SaveFunds(List<Account> accounts)
    {
      using (var writer = new StreamWriter("Accounts.csv"))
      using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
      {
        csv.WriteRecords(accounts);
        writer.Flush();
        // "autosave" abandoned idea
        // autocsv.WriteRecords(accounts);
        // writer.Flush();

      }
    }
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to the Bank.");
      var tracker = new FundTracker();
      var isRunning = true;
      // var reader = new StreamReader("Accounts.csv");
      // var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      // tracker.Accounts = csvReader.GetRecords<Account>().ToList();
      using (var reader = new StreamReader("Accounts.csv"))
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
        tracker.Accounts = csv.GetRecords<Account>().ToList();
      }

      while (isRunning == true)
      {
        foreach (var money in tracker.Accounts)

        {
          Console.WriteLine($"Your {money.AccountType} has a balance of {money.Balance}");
        }

        Console.WriteLine("What do you want to do?");
        Console.WriteLine("(ADD), (WITHDRAW), (TRANSFER), (QUIT)");
        var input = Console.ReadLine().ToLower();
        if (input == "add")
        // need var from user
        {
          Console.WriteLine("What account do you want to add funds to?");
          Console.WriteLine("Select (SAVINGS) (CHECKING)");
          var where = Console.ReadLine().ToLower();
          Console.WriteLine($"How much would you like to add to your {where}?");
          var funds = double.Parse(Console.ReadLine());

          // "Account to update /  how far

          tracker.MakeDeposit(where, funds);
          SaveFunds(tracker.Accounts);
        }
        else if (input == "withdraw")
        {
          Console.WriteLine("What account do you want to withdraw funds from?");
          Console.WriteLine("Select (SAVINGS) (CHECKING)");
          var where = Console.ReadLine().ToLower();
          Console.WriteLine($"How much would you like to remove from your {where} account?");
          var funds = double.Parse(Console.ReadLine());

          tracker.Withdrawl(where, funds);
          SaveFunds(tracker.Accounts);

        }
        else if (input == "transfer")
        {
          Console.WriteLine("What account do you want to transfer funds FROM");
          Console.WriteLine("Select (SAVINGS) (CHECKING)");
          var where = Console.ReadLine().ToLower();
          Console.WriteLine($"How much would you like to remove from your {where} account?");
          var funds = double.Parse(Console.ReadLine());

          tracker.Transfer(where, funds);
          SaveFunds(tracker.Accounts);

          // tracker.Withdrawl(where, funds);
          // SaveFunds(tracker.Accounts);
        }
        else if (input == "quit")
        {
          isRunning = false;
          Console.WriteLine("Goodbye");
          Console.ReadLine();
        }

      }
    }

  }
}
