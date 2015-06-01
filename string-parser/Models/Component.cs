using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public abstract class Component
    {
        public string Name { get; set; }

        public abstract void Add(Component item);
        public abstract void Display(int depth);
        public abstract void Sort();
    }
}
