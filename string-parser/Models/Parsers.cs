using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public static class Parsers
    {
        static string[] LineBreakChars = new string[] { ", ", "(", ")" };

        public static string ParseString(string stringToParse, string lineBreak)
        {
            stringToParse = AddLineBreaks(stringToParse, lineBreak);

            return stringToParse.Replace(", ", " " +lineBreak);
        }

        static string AddLineBreaks(string stringToParse, string lineBreak)
        {
            foreach (var breakers in LineBreakChars)
            {
               stringToParse =  stringToParse.Replace(breakers, " " + lineBreak);
            }
            return stringToParse;
        }
    } 

}
