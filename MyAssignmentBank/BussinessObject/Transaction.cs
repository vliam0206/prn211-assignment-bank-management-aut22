using MyAssignmentBank.Collection;
using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.BussinessObject;

public class Transaction
{
    // Properties
    public int TransId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransDate { get; set; }
    public string? TransType { get; set; } // W:withdraw-rut D:deposit-gui
    // Constructors
    public Transaction()
    {
    }
    public Transaction(decimal amount)
    {
        Amount = amount;
    }
    public Transaction(int transId, decimal amount, string? transType)
    {
        TransId = transId;
        Amount = amount;
        TransType = transType;
    }
    // Overide tostring
    public override string? ToString() => $" + Transaction ID: {this.TransId}; " +
                                          $"Amount: {this.Amount}; " +
                                          $"Date: {this.TransDate}; " +
                                          $"Type: {this.TransType}\n";
    // Overide equal()
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        return this.TransId == ((Transaction)obj).TransId;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    // Input new transaction
    public Transaction InputTransaction(string msg, string type)
    {    
        this.Amount = Inputter.InputPositiveDecimal(msg);
        this.TransDate = DateTime.Now;
        this.TransType = type;
        return this;
    }
}
