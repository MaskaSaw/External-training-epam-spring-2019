using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account;
using Storage;
using Operations;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account.Account> accounts = new List<Account.Account>();
            AccountOperations accountService = new AccountOperations();

            accountService.CreateAccount(new Account.Account(111, "Ivan", "Ivanov", 100m, 5, AccountType.Base));
            accountService.CreateAccount(new Account.Account(112, "Petr", "Petrov", 1250m, 40, AccountType.Gold));
            accountService.CreateAccount(new Account.Account(113, "Sidor", "Sidorov", 10245m, 120, AccountType.Premium));

            PrintAll(accountService.GetAllAccounts());

            accountService.AddAmount(111, 500m);
            PrintAll(accountService.GetAllAccounts());

            Console.ReadKey();
        }

        private static void PrintAll(List<Account.Account> accounts)
        {
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc.ToString());
            }
            Console.WriteLine();
        }
    }
}
