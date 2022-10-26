using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.Util;
public class Menu: List<String>
{
    private String programName;
    public Menu(String programName) : base()
    {
        this.programName = programName;
    }
    
    // Add option to menu
    public void AddChoice(String option)
    {
        this.Add(option);
    }
    public void AddChoice(String[] options)
    {
        this.AddRange(options);
    }

    // Show menu & get choice from menu
    public int GetChoice()
    {
        int choice = -1;
        Console.WriteLine($"\n*****{this.programName}*****");
        try
        {
            for (int i = 0; i < this.Count; i++)
            {
                Console.WriteLine($"{i+1}.  {this[i]}");
            }
            Console.WriteLine("Other.  Quit");

            choice = Inputter.InputPositiveNumber("\n- Your choice: ");
        } 
        catch(IOException ex)
        {
                Console.WriteLine(ex.Message);
        }        
        return choice;
    }

}
