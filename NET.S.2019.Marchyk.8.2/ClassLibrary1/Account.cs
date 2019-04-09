using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public enum AccountType
    {
        Base,
        Gold,
        Premium
    }

    public enum AccountStatus
    {
        Active,
        Close
    }

    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public AccountStatus Status { get; set; }
        public AccountType Type { get; set; }

        public Account(int id, string ownerFirstName, string ownerLastName, decimal amount, int points, AccountType type)
        {
            Id = id;
            FirstName = ownerFirstName;
            LastName = ownerLastName;
            Amount = amount;
            Points = points;
            Status = AccountStatus.Active;
            Type = type;
        }

        public Account()
        {
        }

        public override string ToString()
        {
            return "Account №" + Id + "\n Owner: " + FirstName + " " + LastName + " \n Amount: " + Amount + "$  points:" + Points + "\n Status: " + Status + "  Type: " + Type;
        }
    }
}
