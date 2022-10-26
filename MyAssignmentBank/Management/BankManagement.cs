using MyAssignmentBank.BussinessObject;
using MyAssignmentBank.Collection;
using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.Management;

public class BankManagement : IBankManagement
{
    // Property
    public Branch Bank { get; set; }

    public BankManagement()
    {
        Bank = new Branch();
    }

    // Private methods for this class only
    // Initialize transaction list
    private TransactionList InitTransactions()
    {
        return new TransactionList()
        {
            new Transaction(transId: 1, amount: 120000, transType: "T"),
            new Transaction(transId: 2, amount: 250000, transType: "T"),
            new Transaction(transId: 3, amount: 300000, transType: "D"),
            new Transaction(transId: 4, amount: 500000, transType: "D"),
            new Transaction(transId: 5, amount: 250000, transType: "T")
        };
    }
    
    // Initialize acocunt list
    private AccountList InitAcocunts()
    {
        return new AccountList()
        {
            new Account(accountId: 1, balance: 2500000, transactions: this.InitTransactions()),
            new Account(accountId: 2, balance: 3000000, transactions: this.InitTransactions()),
            new Account(accountId: 3, balance: 1000000, transactions: this.InitTransactions()),
        };
    }
    
    // Choose customer (by customer ID from input)
    private Customer ChooseCustomer()
    {                
        int cusId = Bank.Customers.ChooseID("Choose customer ID: ");
        return Bank.Customers.GetElementByID(cusId);
    }
    
    // Choose account (by account ID from input)
    private Account ChooseAccount(Customer customer)
    {
        int accId = customer.Accounts.ChooseID("Choose account ID: ");
        return customer.Accounts.GetElementByID(accId);
    }
    
    // Public methods
    // Initialize bank branch data
    public void InitBranch()
    {
        // Initialize street
        Address address = new Address(street: "12 Le Van Viet", ward: "Quan 9", city: "Thu Duc");

        // Initialize customer list
        CustomerList customerList = new CustomerList()
        {
            new Customer(cusId: 1, cusName: "Nguyen Van A", cusAddress: address, accounts: this.InitAcocunts()),
            new Customer(cusId: 2, cusName: "Nguyen Van B", cusAddress: address, accounts: this.InitAcocunts()),
            new Customer(cusId: 3, cusName: "Nguyen Van C", cusAddress: address, accounts: this.InitAcocunts()),
            new Customer(cusId: 4, cusName: "Nguyen Van D", cusAddress: address, accounts: this.InitAcocunts()),
            new Customer(cusId: 5, cusName: "Nguyen Van E", cusAddress: address, accounts: this.InitAcocunts())
        };

        // Initialize branch
        Branch branch = new Branch(branchId: 1, branchName: "Init Bank",
                                   branchAddress: address,
                                   customers: customerList);
        this.Bank = branch;
    }    
    
    // Add new customer to branch
    public void AddCustomer()
    {
        // Input new customer & add to customer list
        Customer customer = new Customer().InputCustomer();
        Bank.Customers.AddToList(customer);

        // Inform to the screen
        Printer.InformGreen("\nCreate customer successfully!");
        Console.WriteLine("***Customer infomation***" + customer.ToString());
    }
    
    // Add new account to customer
    public void AddAccount()
    {
        // Choose customer ID (through customer list of this branch)
        Console.WriteLine("Customer List:\n" + Bank.Customers.ToString());
        Customer customer = this.ChooseCustomer();
        Console.WriteLine($"Customer name: {customer.CusName}");
        
        // Input new account & add to account list
        Account account = new Account().InputAccount();
        customer.Accounts.AddToList(account);

        // Inform to the screen
        Printer.InformGreen("\nCreate account successfully!");
        Console.WriteLine("***Account info***\n" + 
                          $"+ Customer ID: {customer.CusId}; Customer name: {customer.CusName}\n" 
                           + account.ToString());

    }
    
    // Print out one customer information
    public void PrintCustomer()
    {
        Customer customer = this.ChooseCustomer();
        Console.WriteLine("\n***Customer infomation***\n"
                            + $"Customer ID: {customer.CusId}\n"
                            + $"Customer name: {customer.CusName}\n"
                            + $"Customer address: {customer.CusAddress}"
                            + "Accounts:\n"
                            + customer.Accounts.ToString());
        
    }
    
    // Withraw
    public void Withraw()
    {
        // Choose customer
        Console.WriteLine($"Customer list of branch {Bank.BranchId} ({Bank.BranchName})\n"
                          + Bank.Customers.ToString());
        Customer customer = this.ChooseCustomer();
        // Choose acccount of that customer
        Console.WriteLine($"Account list of customer {customer.CusName}\n" 
                            + customer.Accounts.ToString());
        Account account = this.ChooseAccount(customer);
        Console.WriteLine("***Account information***\n" + account.ToString());
        // Input withdraw amount
        Transaction transaction = new Transaction().InputTransaction("Input amount to withraw: ", "W");
        // check 
        if (transaction.Amount <= account.Balance)
        {
            // Inform to the screen
            Printer.InformGreen("\nWithdraw successfully!");
            // Update balance of that account
            account.Balance -= transaction.Amount;
            // Add transaction to transactions list of that account
            account.Transactions.AddToList(transaction);
            // Print the result to the screen
            Console.WriteLine("***Transaction infomation***\n" +
                              $"- Customer name: {customer.CusName}\n" +
                              $"- Account:\n {account}" +
                              transaction.ToString());
            return;
        }
        Printer.InformRed($"\nWithdraw failed! This account balance is not enough (Balance: {account.Balance})");
    }
    
    // Deposit
    public void Deposit()
    {
        // Choose customer
        Console.WriteLine($"Customer list of branch {Bank.BranchId} ({Bank.BranchName})\n"
                          + Bank.Customers.ToString());
        Customer customer = this.ChooseCustomer();
        // Choose acccount of that customer
        Console.WriteLine($"Account list of customer {customer.CusName}\n"
                            + customer.Accounts.ToString());
        Account account = this.ChooseAccount(customer);
        Console.WriteLine("***Account information***\n" + account.ToString());
        // Input withdraw amount
        Transaction transaction = new Transaction().InputTransaction("Input amount to deposit: ", "D");
        // Inform to the screen
        Printer.InformGreen("\nDeposit successfully!");
        // Update balance of that account
        account.Balance += transaction.Amount;
        // Add transaction to transactions list of that account
        account.Transactions.AddToList(transaction);
        // Print the result to the screen
        Console.WriteLine("***Transaction infomation***\n" +
                          $"- Customer name: {customer.CusName}\n" +
                          $"- Account:\n {account}" +
                          transaction.ToString());           
    }

}
