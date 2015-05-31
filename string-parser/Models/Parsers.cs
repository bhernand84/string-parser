using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public static class Parsers
    {
        static char[] LineBreakChars = new char[] { ',', '(', ')' };
        
        public static string ParseString(string stringToParse, string lineBreak)
        {
            stringToParse = AddLineBreaks(stringToParse, lineBreak);

            return stringToParse;
        }

        static string AddLineBreaks(string stringToParse, string lineBreak)
        {
            int openParenthesesCount = 0;
            string outputString = null;

            for (int i = 0; i < stringToParse.Length; i++)
            {
                char character = stringToParse[i];
                if (LineBreakChars.Contains(character))
                {
                    if (character == '(')
                    {
                        openParenthesesCount++;
                    }
                    
                    outputString += " " + lineBreak + AddDashes(openParenthesesCount);
                    
                }
                else
                {
                    outputString += character;
                }
            }
            return outputString;
        }

        static string AddDashes(int openParenthesesCount)
        {
            string dashes = null;
            for (int i = 2; i <= openParenthesesCount; i++)
            {
                dashes += "-";
            }
            if (dashes != null)
            {
                dashes += " ";
            }
            return dashes;
        }
    } 

}
