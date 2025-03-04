using Microsoft.VisualBasic;
using SimpleBankingSystem;
using System.Security.Principal;

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
    Console.WriteLine("Enter account type (1 - Regular, 2 - Savings): ");
    int option = Convert.ToInt32(Console.ReadLine());
    return option;
}




Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

var option=0;
while(true)
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
                Console.WriteLine("Enter Account Number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Account Holder Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Initial Balance: ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());


                if (type==1)
                {
                    BankAccount account = new BankAccount();
                    account.CreateAccount(number, name, balance);
                    if (!accounts.ContainsKey(number))
                    {
                        Console.WriteLine("Regular account created successfully!");
                        accounts.Add(number, account);
                    }
                    else
                    {
                        Console.WriteLine("Duplicate Account");
                    }
                }
            }
            break;
        case 2:

            break;
        case 3:
            
            break;
        case 4:
            { 

            }
            break;
        case 5:
            
            break;
    }


}
