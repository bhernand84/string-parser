using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public static class Parsers
    {
        static char[] LineBreakChars = new char[] { '"', ',', '(', ')' };

        public static Component GetCompositeFromString(string stringToParse)
        {
            Composite returnObject = new Composite();

            
            string[] splitString = stringToParse.Split(',');

            return BuildComposite(returnObject, splitString);
        }

        static int index = 0;

        static Composite BuildComposite(Composite composite, string[] stringsToParse)
        {
            while (index < stringsToParse.Length)
            {
                string subString = stringsToParse[index];

                if (subString.Contains("(") || subString.Contains(")"))
                {
                    if (subString.Contains("("))
                    {
                        int indexOfParentheses = subString.IndexOf("(");
                        var newComposite = new Composite(subString.Substring(0, indexOfParentheses));
                        stringsToParse[index] = subString.Substring(indexOfParentheses + 1);
                        composite.Add(BuildComposite(newComposite, stringsToParse));
                        continue;
                    }
                    if (subString.Contains(")"))
                    {
                        int indexOfParentheses = subString.IndexOf(")");
                        composite.Add(new Leaf(subString.Substring(0, indexOfParentheses)));
                        index++;
                        return composite;
                    }
                }
                else
                {
                    composite.Add(new Leaf(subString));
                    index++;
                }
            }
            return composite;
        } 
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
                    if (character == ')')
                    {
                        openParenthesesCount--;
                        continue;
                    }
                    if (character == '"')
                    {
                        continue;
                    }
                    if (stringToParse[i + 1] == ' ')
                    {
                        i++;
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
