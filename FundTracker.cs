using System;
using System.Collections.Generic;
using System.Linq;

namespace NewBankOfSuncoast
{
  public class FundTracker
  {
    public List<Account> Accounts { get; set; } = new List<Account>();

    public void MakeDeposit(string accountType, double balance)
    {
      // need to update list
      Accounts.Find(account => account.AccountType == accountType).Balance += balance;


      // commentend code is irrelevant 
      // Console.WriteLine("Which account would you like to add funds to (CHECKING) (SAVINGS)?");
      // var whereToGo = Console.ReadLine().ToLower();
      // if (whereToGo == "savings")
      // {
      //   {
      //     Console.WriteLine("How much would you like to add to your savings?");
      //     var howMuch = double.Parse(Console.ReadLine());
      //     var savingAccount = Accounts;
      //     {
      //       accountType = whereToGo;
      //     }
      //     // like "var dino" line 32

      //     // var money = Accounts.Find(account => account.AccountType == accountType).Balance += balance;
      //     Accounts.Find(account => account.AccountType == accountType).Balance += balance;
      //   }
      //   Accounts.Add(howMuch.Balance).Where() ToList();
      // }
      // if (whereToGo == "checking ")
      // {
      //   Console.WriteLine("placeholder");
      // }
      // else
      // {
      //   Console.WriteLine("Other placeholder");
      // }
    }
    public void Withdrawl(string accountType, double balance)
    {
      // need to update list
      Accounts.Find(account => account.AccountType == accountType).Balance -= balance;

    }
    public void Transfer(string accountType, double balance)
    {
      Accounts.Find(account => account.AccountType == accountType).Balance -= balance;
      // now need to find a way to mod the other accnt
      Accounts.Find(account => account.AccountType != accountType).Balance += balance;


    }
  }
}


