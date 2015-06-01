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
            Console.WriteLine("Enter test string now:");
            string testString = Console.ReadLine();
            Component returnComposite = Parsers.GetCompositeFromString(testString);

            returnComposite.Sort();
            returnComposite.Display(0);
            Console.ReadLine();
        }

    }
}
