using System.Net.Sockets;

namespace SimpleBankingSystem;

class Program
{
    static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>(); //Generic


    //Validating the number is integer or not.
    public static int ValidateInt(string message, int range1, int range2)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                int input = int.Parse(Console.ReadLine());
                if (input>=range1 && input<=range2)
                {
                    return input;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again!");
            }
        }
    }

    // Validating for deciaml and negative
    public static decimal ValidateDecimal(string message)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                decimal balance = decimal.Parse(Console.ReadLine());
                if (balance<0)
                {
                    throw new Exception();
                }
                else
                {
                    return balance;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again!");
            }
        }
    }





    static void ShowScreen()
    {
        Console.WriteLine("\nSimple Banking System");
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Check Balance");
        Console.WriteLine("5.Apply Interest(Savings Account)");
        Console.WriteLine("6.Exit");

    }

    delegate int GetAccountType();
    public static int AccountType()
    {
        string message = "Enter account type (1 - Regular, 2 - Savings): ";
        int option = ValidateInt(message, 1, 2);
        return option;
    }




    // Create Account Module
    static void CreateAccount(int type)
    {

        int number;
        string message;
        while(true)
        {
            message = "Enter Account Number: ";
            number = ValidateInt(message, 0, 100000);

            if (accounts.ContainsKey(number))
            {
                Console.WriteLine("Duplicate Account!");
            }
            else
            {
                break;
            }
        }
        
        Console.Write("Enter Account Holder Name: ");
        string name = Console.ReadLine();

        message = "Enter Initial Balance: ";
        decimal balance = ValidateDecimal(message);
       
        
        if (type==1)
        {
            BankAccount account = new BankAccount();
            account.CreateAccount(number, name, balance);
            Console.WriteLine("\nRegular account created successfully!");
            accounts.Add(number, account);
        }else if (type==2)
        {
            message = "Enter interest rate (%): ";
            decimal interest_rate = ValidateDecimal(message);
            SavingsAccount account = new SavingsAccount();
            account.CreateAccount(number, name, balance, interest_rate);
            accounts.Add(number, account);
            Console.WriteLine("\nSavings account created successfully!");
        }
    }




    //Check Balance Module

    static void CheckBalance()
    {

        string message = "Enter Account Number: ";
        int number = ValidateInt(message,0,100000);
        if (accounts.ContainsKey(number))
        {
            Console.WriteLine("\nCurrent Balance: $"+accounts[number].CheckBalance());
        }
        else
        {
            Console.WriteLine("\nThere is no such account!");
        }
    }




    //Deposit Module

    static void Deposit()
    {
        int number;
        string message;
        while (true)
        {
            message = "Enter Account Number: ";
            number = ValidateInt(message, 0, 100000);

            if (!accounts.ContainsKey(number))
            {
                Console.WriteLine("\nNo such account! ");
            }
            else
            {
                break;
            }
        }
        
        message = "Enter Deposited Amount: ";
        decimal amount = ValidateDecimal(message);

        accounts[number].Deposit(amount);
        Console.WriteLine("\nDeposited $"+amount+" .New Balance $"+accounts[number].CheckBalance());
          
    }





    //Withdraw Module

    static void Withdraw()
    {
        int number;
        string message;

        while (true)
        {
            message = "Enter Account Number: ";
            number = ValidateInt(message, 0, 1000000);
            if (!accounts.ContainsKey(number))
            {
                Console.WriteLine("\nNo such account! ");
            }
            else
            {
                break;
            }
        }
        message = "Enter Withdraw Amount: ";
        decimal amount = ValidateDecimal(message);

        if (accounts[number].Withdraw(amount))
        {
            Console.WriteLine("\nWithdraw successful! New Balance: $"+accounts[number].CheckBalance());
        }
        else
        {
            Console.WriteLine("\nNot enough balance to withdraw!");
        }
        
        
    }




    //ApplyInterest for Savings Account

    static void ApplyInterest()
    {
        string message = "Enter account number: ";
        int number = ValidateInt(message,0,1000000);
        if (accounts.ContainsKey(number))
        {
            decimal interest = accounts[number].ApplyInterest();
            Console.WriteLine("\nInterest Applied: $" + interest + " .New Balance: $" + accounts[number].CheckBalance());
        }
        else
        {
            Console.WriteLine("\nNo such account!");
        }
    }






    //Flow control of console from here.
    static void Main()
    {
        

        int option = 0;
        while (true)
        {
            ShowScreen();
            string message = "Choose an option: ";
            option = ValidateInt(message,1,6);
            if (option==6) break;
            switch (option)
            {
                case 1:
                    {
                        GetAccountType del = AccountType;
                        int type = del(); // Using delegates here.
                        CreateAccount(type);
                    }
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    CheckBalance();
                    break;
                case 5:
                    ApplyInterest();
                    break;
            }
        }
    }
}