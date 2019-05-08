using System;
using System.Collections.Generic;
using System.Linq;
using BankAccount;
using Storage;

namespace Operations
{
    public class AccountOperations
    {
        private readonly AccountStorage _accountStorage;

        public AccountOperations()
        {
            _accountStorage = new AccountStorage();
        }
     
        public List<Account> GetAllAccounts()
        {
            return _accountStorage.ReadAccountFromFile();
        }

        
        public void AddAmount(int id, decimal amount)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close) throw new ArgumentException("Account is closed");
            account.Amount = account.Amount + amount;

            if (account.Type == AccountType.Base)
                account.Points += 10;

            if (account.Type == AccountType.Gold)
                account.Points += 20;

            if (account.Type == AccountType.Premium)
                account.Points += 30;
        }

       
        public void DivAmount(int id, decimal amount)
        {
            var account = FindAccount(id);
            if (account.Status == AccountStatus.Close) throw new ArgumentException("Account is closed");
            account.Amount = account.Amount - amount;
        }

       
        public void CreateAccount(Account account)
        {
            _accountStorage.AppendAccountToFile(account);
        }

       
        public void CloseAccount(int id)
        {
            if (id < 0) throw new ArgumentException();

            var account = FindAccount(id);
            account.Status = AccountStatus.Close;
        }

        private Account FindAccount(int id)
        {

            var accounts = _accountStorage.ReadAccountFromFile().ToList();
            return accounts.FirstOrDefault(account => account.Id == id);
        }
    }
}
