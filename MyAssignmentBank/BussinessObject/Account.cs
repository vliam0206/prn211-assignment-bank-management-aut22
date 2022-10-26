using MyAssignmentBank.Collection;
using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.BussinessObject;

public class Account
{
    // Properties
    public int AccountId { get; set; }
    public decimal Balance { get; set; }
    public TransactionList Transactions { get; set; }
    // Constructors
    public Account()
    {
        Transactions = new TransactionList();
    }

    public Account(decimal balance, TransactionList transactions)
    {
        Balance = balance;
        Transactions = transactions;
    }

    public Account(int accountId, decimal balance, TransactionList transactions)
    {
        AccountId = accountId;
        Balance = balance;
        Transactions = transactions;
    }
    // Overide tostring()
    public override string? ToString() =>$"+ Account ID: {this.AccountId}; " +
                                         $"Balance: {this.Balance}; " +
                                         $"Num of transactions: {Transactions.Count()}\n";
    // Overide equal()    
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        return this.AccountId == ((Account)obj).AccountId;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    // Input new account
    public Account InputAccount()
    {
        Console.WriteLine("\n-- Input account's infomation --");

        //int id = Inputter.InputPositiveNumber("Account ID: ");        
        this.Balance = Inputter.InputPositiveDecimal("Balance: ");
        this.Transactions = new TransactionList();
        return this;
    }
   
}
