using MyAssignmentBank.Collection;
using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.BussinessObject;
public class Customer
{
    // Properties
    public int CusId { get; set; }
    public string? CusName { get; set; }
    public Address CusAddress { get; set; }
    public AccountList Accounts { get; set; }
    // Constructors
    public Customer()
    {
        CusAddress = new Address();
        Accounts = new AccountList();
    }
    public Customer(string cusName, Address cusAddress, AccountList accounts)
    {
        CusName = cusName;
        CusAddress = cusAddress;
        Accounts = accounts;
    }
    public Customer(int cusId, string cusName, Address cusAddress, AccountList accounts)
    {
        CusId = cusId;
        CusName = cusName;
        CusAddress = cusAddress;
        Accounts = accounts;
    }
    // Overide tostring
    public override string? ToString() => $"\n- Customer ID: {this.CusId}  " +
                                          $"- Customer name: {this.CusName}  " +
                                          this.CusAddress.ToString()
                                          /*+  this.Accounts.ToString()*/;
    // Overide equal()    
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        return this.CusId == ((Customer)obj).CusId;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    // Input new customer
    public Customer InputCustomer()
    {
        Console.WriteLine("\n-- Input customer's infomation --");     
        this.CusName = Inputter.InputNonBlankString("Customer name: ");
        this.CusAddress = new Address().InputAddress();
        this.Accounts = new AccountList();
        return this;
    }

    
}
