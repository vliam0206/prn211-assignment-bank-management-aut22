using MyAssignmentBank.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.Collection;
public class CustomerList : BaseList<Customer>
{
    // Add one customer to the list (with the id auto generated)
    public override void AddToList(Customer customer)
    {
        customer.CusId = this.Count + 1;
        this.Add(customer);
    }
    // Get one customer from list by id
    public override Customer GetElementByID(int id) => (from cus in this
                                                                  where cus.CusId == id
                                                                  select cus).ToArray().First();
}
