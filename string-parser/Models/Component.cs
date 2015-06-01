﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public interface Component
    {
        string Name;
        void Add();
        void Display(int depth);
    }
}