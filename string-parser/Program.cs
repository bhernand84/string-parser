using string_parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter test string now:");
            //string testString = Console.ReadLine();

            //Console.WriteLine(Parsers.ParseString(testString, "\n"));
            var returnComposite = Parsers.GetCompositeFromString("(id,created,employee(id,firstname,employeeType(id), lastname),location)");

            returnComposite.Display(0);
            Console.ReadLine();
        }

    }
}
