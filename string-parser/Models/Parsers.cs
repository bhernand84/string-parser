using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public static class Parsers
    {
        public static string ParseString(string stringToParse, string lineBreak)
        {
            return stringToParse.Replace(", ", " " +lineBreak);
        }
    } 

}
