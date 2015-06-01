using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    class Composite :Component
    {
        public string Name
        { get; set; }

        private List<Component> children = new List<Component>();

        public void Add(Component item)
        {
            children.Add(item);
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " " + Name);
            foreach (Component component in children)
            {
                component.Display(depth + 1);
            }
        }
    }
}
