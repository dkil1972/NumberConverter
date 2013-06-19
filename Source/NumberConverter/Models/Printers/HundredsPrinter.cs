using System.Collections.Generic;
using System.Linq;

namespace NumberConverter.Models.Printers
{
    public class HundredsPrinter : IPrintNumbers
    {
        private readonly IList<IPrintNumbers> childPrinters = new List<IPrintNumbers>();

        public HundredsPrinter(IPrintNumbers childPrinter)
        {
            childPrinters.Add(childPrinter);
        }

        public HundredsPrinter()
        {
        }

        public string Print(Number value)
        {
            if(value.IsExactMultipleOf(100))
                return childPrinters.First().Print(value.FirstDigit()) + " hundred";

            if (value.Digit(2).IsZero())
                return childPrinters.First().Print(value.FirstDigit()) + " hundred and " +
                       childPrinters.First().Print(value.LastDigit());

            return childPrinters.First().Print(value.FirstDigit()) + " hundred and " +
                   childPrinters.Last().Print(value.LastDigitsStartingAt(2));
        }

        public void Add(IPrintNumbers childPrinter)
        {
            childPrinters.Add(childPrinter);
        }
    }
}