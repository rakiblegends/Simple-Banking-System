namespace SimpleBankingSystem;

class Program
{
    static Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
    static Dictionary<int,SavingsAccount> accounts1 = new Dictionary<int, SavingsAccount>();

    static void ShowScreen()
    {
        Console.WriteLine("Simple Banking System");
        Console.WriteLine("1. Create Account");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Check Balance");
        Console.WriteLine("5.Apply Interest(Savings Account)");
        Console.WriteLine("6.Exit");

    }

    static int GetAccountType()
    {
        Console.Write("Enter account type (1 - Regular, 2 - Savings): ");
        int option = Convert.ToInt32(Console.ReadLine());
        return option;
    }

    // Create Account Module
    static void CreateAccount(int type)
    {
        Console.Write("Enter Account Number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Account Holder Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Initial Balance: ");
        decimal balance = Convert.ToDecimal(Console.ReadLine());
        if (type==1)
        {
            if (!(accounts.ContainsKey(number)) )
            {
                BankAccount account = new BankAccount();
                account.CreateAccount(number, name, balance);
                Console.WriteLine("Regular account created successfully!");
                accounts.Add(number, account);
            }
            else
            {
                Console.WriteLine("Duplicate Account");
            }
        }else if (type==2)
        {
            if (!(accounts.ContainsKey(number))){
                Console.Write("Enter interest rate (%): ");
                decimal interest_rate = Convert.ToDecimal(Console.ReadLine());
                SavingsAccount account = new SavingsAccount();
                account.CreateAccount(number, name, balance, interest_rate);
                accounts1.Add(number, account);
                Console.WriteLine("Savings account created successfully!");
            }
            else
            {
                Console.WriteLine("Duplicate account");
            }
        }
    }


    //Check Balance Module

    static void CheckBalance()
    {
        Console.Write("Enter Account Number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (accounts.ContainsKey(number))
        {
            Console.WriteLine("Current Balance: $"+accounts[number].CheckBalance());
        }
        else if (accounts1.ContainsKey(number))
        {
            Console.WriteLine("Current Balance: $"+accounts1[number].CheckBalance());
        }
    }

    //Deposit Module

    static void Deposit()
    {
        Console.Write("Enter Account Number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Deposited Amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (accounts.ContainsKey(number))
        {
            accounts[number].Deposit(amount);
            Console.WriteLine("Deposited $"+amount+" .New Balance $"+accounts[number].CheckBalance());
            
        }
        else if (accounts1.ContainsKey(number))
        {
            accounts1[number].Deposit(amount);
            Console.WriteLine("Deposited $"+amount+" .New Balance $"+accounts1[number].CheckBalance());
        }
        else
        {
            Console.WriteLine("No such account! ");
        }
    }


    //Withdraw Module

    static void Withdraw()
    {
        Console.Write("Enter Account Number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Deposited Amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (accounts.ContainsKey(number))
        {
            if (accounts[number].Withdraw(amount))
            {
                accounts[number].Withdraw(amount);
                Console.WriteLine("Withdraw successful! New Balance: $"+accounts[number].CheckBalance());
            }
            else
            {
                Console.WriteLine("Not enough balance to withdraw!");
            }
        }
        else if (accounts1.ContainsKey(number))
        {
            if (accounts1[number].Withdraw(amount))
            {
                accounts1[number].Withdraw(amount);
                Console.WriteLine("Withdraw successful! New Balance: $"+accounts1[number].CheckBalance());
            }
            else
            {
                Console.WriteLine("Not enough balance to withdraw!");
            }
        }
        else
        {
            Console.WriteLine("No such account!");
        }
        
    }

    //ApplyInterest for Savings Account

    static void ApplyInterest()
    {
        Console.WriteLine("Enter account number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        accounts1[number].ApplyInterest();
    }







    static void Main()
    {
        

        var option = 0;
        while (true)
        {
            ShowScreen();
            Console.WriteLine("Choose an option: ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option==6) break;
            switch (option)
            {
                case 1:
                    {
                        int type = GetAccountType();
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