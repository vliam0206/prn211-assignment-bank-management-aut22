using MyAssignmentBank.BussinessObject;
using MyAssignmentBank.Collection;
using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.View;
public class ObjectInputter
{
    // Input new account
    public static Account InputAccount()
    {
        Console.WriteLine("\n-- Input account's infomation --");
        
        //int id = Inputter.InputPositiveNumber("Account ID: ");        
        decimal initBalance = Inputter.InputPositiveDecimal("Balance: ");
        return new Account(balance: initBalance, transactions: new TransactionList());
    }
    // Input new customer
    public Customer InputCustomer()
    {
        Console.WriteLine("\n-- Input customer's infomation --");

        //int id = Inputter.InputPositiveNumber("Customer ID: ");        
        string name = Inputter.InputNonBlankString("Customer name: ");
        Address address = InputAddress();
        return new Customer(cusName: name, cusAddress: address,
                                         accounts: new AccountList());
    }
    // Input new address
    public Address InputAddress()
    {
        Console.WriteLine("\n-- Input address's infomation --");

        string tStreet = Inputter.InputNonBlankString("Street: ");
        string tWard = Inputter.InputNonBlankString("Ward: ");
        string tCity = Inputter.InputNonBlankString("City: ");
        return new Address(street: tStreet, ward: tWard, city: tCity);
    }
    // Input new transaction
    public Transaction InputTransaction()
    {
        Console.WriteLine("\n-- Input transaction's infomation --");
        //int transId = Inputter.InputPositiveNumber("Transaction ID: ");
        decimal amount = Inputter.InputPositiveDecimal("Amount: ");
        return new Transaction(amount: amount);
    }
}
