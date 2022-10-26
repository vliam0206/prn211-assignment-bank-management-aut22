using MyAssignmentBank.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentBank.BussinessObject;

public class Address
{
    // Properties
    public string? Street { get; set; }
    public string? Ward { get; set; }
    public string? City { get; set; }
    // Constructors
    public Address()
    {
    }
    public Address(string? street, string? ward, string? city)
    {
        Street = street;
        Ward = ward;
        City = city;
    }
    // Overide tostring
    public override string ToString() => $"- Address: {Street}, {Ward}, {City}\n";
    // Input new address
    public Address InputAddress()
    {
        Console.WriteLine("\n-- Input address's infomation --");

        this.Street = Inputter.InputNonBlankString("Street: ");
        this.Ward = Inputter.InputNonBlankString("Ward: ");
        this.City= Inputter.InputNonBlankString("City: ");
        return this;
    }
}
