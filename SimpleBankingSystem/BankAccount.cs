using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
    class BankAccount
    {
        public int Number { get; set; }
        public decimal Balance { get;  set; }
        public string Name { get; set; }
        public decimal Interest { get; set; }
        public void CreateAccount(int number, string name, decimal balance)
        {
            Number = number;
            Balance = balance;
            Name = name;
            Interest = 0;
        }
        
        public void Deposit(decimal amount)
        {
              Balance+=amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (amount<=Balance)
            {
                Balance-= amount;
                return true;
            }
            else return false;
        }
        public decimal CheckBalance()
        {
            return Balance;
        }
        public decimal ApplyInterest()
        {
            decimal interest = (Balance*(Interest)/100.00M);
            Balance = Balance+interest;
            return interest;
        }
    }
}
