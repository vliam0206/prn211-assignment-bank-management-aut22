using MyAssignmentBank.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.Collection;
public class TransactionList : BaseList<Transaction>
{
    // Add one transaction to the list (with the id auto generated)
    public override void AddToList(Transaction transaction)
    {
        transaction.TransId = this.Count + 1;
        this.Add(transaction);
    }
    // Get one transaction from list by id
    public override Transaction GetElementByID(int id) => (from trans in this
                                                           where trans.TransId == id
                                                           select trans).ToArray().First();
    
}
