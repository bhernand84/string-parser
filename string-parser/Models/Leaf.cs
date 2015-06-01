using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    class Leaf :Component
    {

        public string Name
        { get; set; }
        void Component.Add()
        {
            throw new InvalidOperationException("Cannot add to leaf node");
        }

        void Component.Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " " + Name);
        }
    }
}
