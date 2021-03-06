﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public class Leaf :Component
    {

        public override void Add(Component item)
        {
            throw new InvalidOperationException("Cannot add to leaf node");
        }

        public override void Sort()
        {

        }

        public override void Display(int depth)
        {

            if (depth > 2)
            {
                Console.WriteLine(new String('-', (depth - 2)) + " " + Name);
            }
            else
            {
                Console.WriteLine(Name);
            }
        }

        public Leaf() { }
        public Leaf(string name)
        {
            Name = name.Trim() ;
        }
    }
}
