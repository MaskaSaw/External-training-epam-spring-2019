using BankAccount;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storage
{
    public class AccountStorage
    {
      
        private const string Path = "D:\\Folder";
       
        public List<Account> ReadAccountFromFile()
        {
            var accounts = new List<Account>();
            using (var br = new BinaryReader(File.Open(Path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var account = Reader(br);
                    accounts.Add(account);
                }
            }

            return accounts;
        }

       
        public void AppendAccountToFile(Account account)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, account);
            }
        }

       
        public void OverWriteFile(IEnumerable<Account> accounts)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var account in accounts)
                    Writer(bw, account);
            }
        }

        private static void Writer(BinaryWriter binary, Account account)
        {
            binary.Write(account.Id.ToString());
            binary.Write(account.FirstName);
            binary.Write(account.LastName);
            binary.Write(account.Amount);
            binary.Write(account.Points);
            binary.Write(account.Status.ToString());
            binary.Write(account.Type.ToString());

        }

        private static Account Reader(BinaryReader binary)
        {
            var id = binary.ReadString();
            var firstName = binary.ReadString();
            var lastName = binary.ReadString();
            var amount = binary.ReadDecimal();
            var points = binary.ReadInt32();
            var status = binary.ReadString();
            var type = binary.ReadString();

            return new Account(Convert.ToInt32(id), firstName, lastName, amount, points, (AccountType)Enum.Parse(typeof(AccountType), type))
            {
                Status = (AccountStatus)Enum.Parse(typeof(AccountStatus), status)
            };

        }

    }
}
