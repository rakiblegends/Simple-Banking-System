using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
    class SavingsAccount: BankAccount
    {
        public decimal Interest { get; set; }
        public void CreateAccount(int number, string name, decimal balance, decimal interest)
        {
            Number = number;
            Name = name;
            Balance = balance;
            Interest = interest;
        }
        public void ApplyInterest()
        {
            Balance = Balance+(Balance*(Interest/100.00M));
        }
    }
}
