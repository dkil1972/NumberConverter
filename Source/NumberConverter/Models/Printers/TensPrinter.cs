using System.Collections.Generic;
using System.Linq;

namespace NumberConverter.Models.Printers
{
    public class TensPrinter : IPrintNumbers
    {
        private readonly IDictionary<int, string> teenToTextMap = new Dictionary<int, string>
            {
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eighteen"},
                {19, "nineteen"},
            };

        private readonly IDictionary<char, string> tensToTextMap = new Dictionary<char, string>
            {
                {'2', "twenty"},
                {'3', "thirty"},
                {'4', "forty"},
                {'5', "fifty"},
                {'6', "sixty"},
                {'7', "seventy"},
                {'8', "eighty"},
                {'9', "ninety"},
            };

        private readonly IList<IPrintNumbers> childPrinters = new List<IPrintNumbers>();

        public string Print(int value)
        {
            if (value < 20)
                return teenToTextMap[value];

            var firstDigit = value.ToString()[0];

            return tensToTextMap[firstDigit] + " " + childPrinters.Single().Print(int.Parse(value.ToString()[1].ToString()));
        }

        public void Add(IPrintNumbers childPrinter)
        {
            childPrinters.Add(childPrinter);
        }
    }
}