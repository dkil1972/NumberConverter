using System.Collections.Generic;
using System.Linq;

namespace NumberConverter.Models.Printers
{
    public class HundredsPrinter : IPrintNumbers
    {
        private readonly IList<IPrintNumbers> childPrinters = new List<IPrintNumbers>();

        public string Print(int value)
        {
            var firstDigit = value.ToString()[0];
            var secondDigit = int.Parse(value.ToString()[1].ToString());
            var thirdDigit = int.Parse(value.ToString()[2].ToString());

            if(secondDigit == 0 && thirdDigit == 0)
                return childPrinters.First().Print(int.Parse(firstDigit.ToString())) + " hundred";

            if (secondDigit == 0)
                return childPrinters.First().Print(int.Parse(firstDigit.ToString())) + " hundred and " +
                       childPrinters.First().Print(thirdDigit);

            return childPrinters.First().Print(int.Parse(firstDigit.ToString())) + " hundred and " +
                   childPrinters.Last().Print(int.Parse(secondDigit.ToString() + thirdDigit.ToString()));
        }

        public void Add(IPrintNumbers childPrinter)
        {
            childPrinters.Add(childPrinter);
        }
    }
}