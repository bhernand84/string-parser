using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_parser.Models
{
    public static class Parsers
    {
        public static Component GetCompositeFromString(string stringToParse)
        {
            Composite returnObject = new Composite();

            stringToParse = stringToParse.StripIllegalCharacters();

            string[] splitString = stringToParse.Split(',');

            return BuildComposite(returnObject, splitString);
        }

        static int stringArrayIndex = 0;

        static Composite BuildComposite(Composite composite, string[] stringsToParse)
        {
            while (stringArrayIndex < stringsToParse.Length)
            {
                string subString = stringsToParse[stringArrayIndex];

                if (subString.Contains("(") || subString.Contains(")"))
                {
                    if (subString.Contains("("))
                    {
                        int indexOfParentheses = subString.IndexOf("(");
                        var newComposite = new Composite(subString.Substring(0, indexOfParentheses));
                        stringsToParse[stringArrayIndex] = subString.Substring(indexOfParentheses + 1);
                        composite.Add(BuildComposite(newComposite, stringsToParse));
                        continue;
                    }
                    if (subString.Contains(")"))
                    {
                        int indexOfParentheses = subString.IndexOf(")");
                        composite.Add(new Leaf(subString.Substring(0, indexOfParentheses)));
                        stringArrayIndex++;
                        return composite;
                    }
                }
                else
                {
                    composite.Add(new Leaf(subString));
                    stringArrayIndex++;
                }
            }
            return composite;
        }

        private static string StripIllegalCharacters(this string myString)
        {
            return myString.Replace("\"", "");
        }
    }
}
