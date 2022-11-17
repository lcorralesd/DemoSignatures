using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Models;
internal class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public Phone Phone { get; set; }
    public DateOnly BirthDay { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }

}
