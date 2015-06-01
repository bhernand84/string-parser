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
            var parsedString = Parsers.ParseString("(hi(hi(hi),hi)", LineBreak);
            string expectedOutput = String.Format(" {0}hi {0}- hi {0}-- hi {0}- hi", LineBreak);
            Assert.AreEqual(expectedOutput, parsedString);
        }

        [TestMethod]
        public void leadingSpacesAreRemoved()
        {
            var parsedString= Parsers.ParseString("hi, hi", LineBreak);
            var expectedOutput = String.Format("hi {0}hi", LineBreak);
            Assert.AreEqual(expectedOutput,parsedString);

        }
        [TestMethod]
        public void testParserAgainstFullString()
        {
            var parsedString = Parsers.ParseString("(id,created,employee(id,firstname,employeeType(id), lastname),location)", LineBreak);
            string expectedOutput = String.Format(" {0}id {0}created {0}employee {0}- id {0}- firstname {0}- employeeType {0}-- id {0}- lastname {0}location", LineBreak);
            Assert.AreEqual(expectedOutput, parsedString);
        }

        [TestMethod]
        public void commasCreateTwoLeafObjects()
        {
            var returnComposite = Parsers.GetCompositeFromString("(id,created,employee(id,firstname,employeeType(id), lastname),location)");

            returnComposite.Display(0);
        }
    }
}
