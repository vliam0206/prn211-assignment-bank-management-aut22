
using MyAssignmentBank.BussinessObject;
using MyAssignmentBank.Collection;
using MyAssignmentBank.Management;
using MyAssignmentBank.Util;
using System.Diagnostics;

public class Program
{
    // Create menu
    public static Menu CreateMenu()
    {
        string[] options = {"Reset to deafault branch", //1
                            "Create new branch", //2
                            "Add new customer (a)", //3
                            "Add new account to customer (a)", //4
                            "Print out one customer's information (b)", //5
                            "Withdraw (c)", //6
                            "Deposit(c)", //7
                            "List all transactions (d)", //8
                            "List maximum balance accounts of each cusomer (e)", //9
                            "List all customer (by total balance - ASC) (f)", //10
                            "Print out VIP - customer with most transactions (g)" };//11

        Menu menu = new Menu("BANK MANAGEMENT SYSTEM");
        menu.AddChoice(options);
        return menu;
    }
    
    public static void Main()
    {
        // Create menu
        Menu menu = CreateMenu();

        // Initialize origin data        
        BankManagement bankManagement = new BankManagement();
        bankManagement.InitBranch();

        // Start application
        int choice = -1;
        do
        {
            choice = menu.GetChoice();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- Reset to defaul branch ---");
                    bankManagement.InitBranch();
                    // Inform to the screen
                    Printer.InformGreen("\nReset branch successfully!");
                    Console.WriteLine(bankManagement.Bank.ToString());
                    break;
                case 2:
                    Console.WriteLine("\n--- Create new branch ---");
                    bankManagement.Bank.InputBranch();
                    // Inform to the screen
                    Printer.InformGreen("\nCreate branch successfully!");
                    Console.WriteLine(bankManagement.Bank.ToString());
                    break;
                case 3:
                    Console.WriteLine("\n--- Add new customer ---");
                    bankManagement.AddCustomer();                    
                    break;
                case 4:
                    Console.WriteLine("\n--- Add new account ---");
                    bankManagement.AddAccount();
                    break;
                case 5:
                    Console.WriteLine("\n--- Print out customer's infomation ---");
                    bankManagement.PrintCustomer();
                    break;
                case 6:
                    Console.WriteLine("\n--- Widthraw ---");
                    bankManagement.Withraw();
                    break;
                case 7:
                    Console.WriteLine("\n--- Deposit ---");
                    break;
                case 8:
                    Console.WriteLine("\n--- List max balance account of each customer ---");
                    break;
                case 9:
                    Console.WriteLine("\n--- List all customers by ascending total balance ---");
                    break;
                case 10:
                    Console.WriteLine("\n--- Print out customer which have most transactions ---");
                    break;
            }
        }
        while (choice > 0 & choice <= menu.Count);
    }
}