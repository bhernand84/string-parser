using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using string_parser.Models;

namespace string_parser_tests
{
    [TestClass]
    public class StringParseTests
    {

        public string LineBreak = "/n";
        [TestMethod]
        public void commasCreateALineBreak()
        {
            var parsedString = Parsers.ParseString("hi,hi", LineBreak);
            string expectedOutput = String.Format("hi {0}hi", LineBreak) ;
            Assert.AreEqual( expectedOutput,  parsedString);
        }

        [TestMethod]
        public void parenthesesCreateALineBreak()
        {
            var parsedString = Parsers.ParseString("(hi hi", LineBreak);
            string expectedOutput = String.Format(" {0}hi hi", LineBreak);
            Assert.AreEqual(expectedOutput, parsedString);
        }

        [TestMethod]
        public void nestedOpenParenthesesAddsDashPrefix()
        {
            var parsedString = Parsers.ParseString("(hi(hi", LineBreak);
            string expectedOutput = String.Format(" {0}hi {0}- hi", LineBreak);
            Assert.AreEqual(expectedOutput, parsedString);
        }
        [TestMethod]
        public void twoNestedOpenParenthesesAddsDashPrefixes()
        {
            var parsedString = Parsers.ParseString("(hi(hi(hi", LineBreak);
            string expectedOutput = String.Format(" {0}hi {0}- hi {0}-- hi", LineBreak);
            Assert.AreEqual(expectedOutput, parsedString);
        }

        [TestMethod]
        public void closingParenthesesRemovesDashForNestedObjects()
        {
            var parsedString = Parsers.ParseString("(hi(hi(hi),hi", LineBreak);
            string expectedOutput = String.Format(" {0}hi {0}- hi {0}-- hi {0}- hi", LineBreak);
            Assert.AreEqual(expectedOutput, parsedString);
        }
    }
}
