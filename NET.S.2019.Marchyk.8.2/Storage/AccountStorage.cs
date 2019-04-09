using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Account;

namespace Storage
{
    public class AccountStorage
    {
      
        private const string Path = "D:\\Folder";
       
        public List<Account.Account> ReadAccountFromFile()
        {
            var accounts = new List<Account.Account>();
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

       
        public void AppendAccountToFile(Account.Account account)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, account);
            }
        }

       
        public void OverWriteFile(IEnumerable<Account.Account> accounts)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var account in accounts)
                    Writer(bw, account);
            }
        }

        private static void Writer(BinaryWriter binary, Account.Account account)
        {
            binary.Write(account.Id.ToString());
            binary.Write(account.FirstName);
            binary.Write(account.LastName);
            binary.Write(account.Amount);
            binary.Write(account.Points);
            binary.Write(account.Status.ToString());
            binary.Write(account.Type.ToString());

        }

        private static Account.Account Reader(BinaryReader binary)
        {
            var id = binary.ReadString();
            var firstName = binary.ReadString();
            var lastName = binary.ReadString();
            var amount = binary.ReadDecimal();
            var points = binary.ReadInt32();
            var status = binary.ReadString();
            var type = binary.ReadString();

            return new Account.Account()
            {
                Id = Convert.ToInt32(id),
                FirstName = firstName,
                LastName = lastName,
                Amount = amount,
                Points = points,
                Status = (AccountStatus)Enum.Parse(typeof(AccountStatus), status),
                Type = (AccountType)Enum.Parse(typeof(AccountType), type)
            };

        }

    }
}
