using MyAssignmentBank.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.Collection;

public class AccountList : BaseList<Account>
{
    // Add one account to the list (with the id auto generated)
    public override void AddToList(Account account)
    {
        account.AccountId = this.Count + 1;
        this.Add(account);
    }

    public override Account GetElementByID(int id) => (from acc in this
                                                       where acc.AccountId == id 
                                                        select acc).ToArray().First();

}
