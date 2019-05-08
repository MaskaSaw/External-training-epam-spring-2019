using System;
using System.Collections.Generic;
using Operations;
using BankAccount;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            AccountOperations accountService = new AccountOperations();

            accountService.CreateAccount(new Account(111, "Ivan", "Ivanov", 100m, 5, AccountType.Base));
            accountService.CreateAccount(new Account(112, "Petr", "Petrov", 1250m, 40, AccountType.Gold));
            accountService.CreateAccount(new Account(113, "Sidor", "Sidorov", 10245m, 120, AccountType.Premium));

            PrintAll(accountService.GetAllAccounts());

            accountService.AddAmount(111, 500m);
            PrintAll(accountService.GetAllAccounts());

            Console.ReadKey();
        }

        private static void PrintAll(List<Account> accounts)
        {
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc.ToString());
            }
            Console.WriteLine();
        }
    }
}
