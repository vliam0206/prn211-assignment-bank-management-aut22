using MyAssignmentBank.Collection;
using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.BussinessObject;

public class Branch
{
    // Properties
    public int BranchId { get; set; }
    public string? BranchName { get; set; }
    public Address BranchAddress { get; set; }
    public CustomerList Customers { get; set; }
    // Constructors
    public Branch()
    {
        BranchAddress = new Address();
        Customers = new CustomerList();
    }
    public Branch(string? branchName, Address branchAddress, CustomerList customers)
    {
        BranchName = branchName;
        BranchAddress = branchAddress;
        Customers = customers;
    }
    public Branch(int branchId, string? branchName, Address branchAddress, CustomerList customers)
    {
        BranchId = branchId;
        BranchName = branchName;
        BranchAddress = branchAddress;
        Customers = customers;
    }
    // Overide tostring
    public override string? ToString() => "\n***Branch Info***\n" +
                                        $"- Branch ID: {this.BranchId}\n" +
                                        $"- Branch name: {this.BranchName}\n" +
                                        this.BranchAddress.ToString() +
                                        /*this.Customers.ToString() +*/ "\n";
    // Overide equal()    
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        return this.BranchId == ((Branch)obj).BranchId;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    // Input new branch
    public Branch InputBranch()
    {
        Console.WriteLine("\n-- Input branch's infomation --");
        this.BranchName = Inputter.InputNonBlankString("Branch name: ");
        this.BranchAddress = new Address().InputAddress();
        this.Customers = new CustomerList();
        return this;
    }
    
}
