using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MyAssignmentBank.Util;
public class Inputter
{
    public static int InputPositiveNumber(string msg)
    {        
        int inputted = -1;
        do
        {
            Write(msg);
            int.TryParse(ReadLine(), out inputted);
            if (inputted <= 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid input!\nInput value must be a number greater than 0. Please try again!\n");
                ResetColor();
            }
        } while (inputted <= 0);
        return inputted;
    }

    public static decimal InputPositiveDecimal(string msg)
    {
        decimal inputted = -1;
        do
        {
            Write(msg);
            decimal.TryParse(ReadLine(), out inputted);
            if (inputted <= 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid input!\nInput value must be a double greater than 0. Please try again!\n");
                ResetColor();
            }
        } while (inputted <= 0);
        return inputted;
    }

    public static string InputNonBlankString(string msg)
    {
        string inputted = "";
        do
        {
            Write(msg);
            inputted = ReadLine().Trim();
            if (inputted.Equals(""))
            {
                WriteLine("Input value must be non-blank string. Please try again!\n");
            }
        } while (inputted.Equals(""));
        return inputted;
    }
    

}
