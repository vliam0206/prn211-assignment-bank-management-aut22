using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.Collection;

public abstract class BaseList<E> : List<E>
{
    // Add one element to the list (with the id auto generated)
    public abstract void AddToList(E element);
    
    // Get one element from list by id
    public abstract E GetElementByID(int id);        

    // Check whether an element is existed in list
    public bool IsExist(E element) => (from e in this 
                                       where e.Equals(element) 
                                       select e) == null;
    // Input ID that existed in the list
    public int ChooseID(string msg)
    {
        int id = -1;
        do
        {
            id = Inputter.InputPositiveNumber(msg);
            if (id <= 0 || id > this.Count)
            {
                Printer.InformRed("ID does not exit! Please try again.\n");
            }
        } while (id <= 0 || id > this.Count);
        // inform to the screen
        Printer.InformGreen("Valid ID (OK).\n");
        return id;
    }
    
    // Overide ToString mehotd for list output
    public override string? ToString()
    {
        string result = "";
        foreach (var element in this)
        {
            result += element?.ToString();
        }
        return result;
    }    
}
