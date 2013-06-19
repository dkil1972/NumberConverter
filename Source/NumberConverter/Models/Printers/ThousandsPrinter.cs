using System.Collections.Generic;
using System.Linq;

namespace NumberConverter.Models.Printers
{
    public class ThousandsPrinter : IPrintNumbers
    {
        IList<IPrintNumbers> childPrinters = new List<IPrintNumbers>();

        public string Print(Number value)
        {
            if (value.IsExactMultipleOf(1000))
                return childPrinters.First().Print(value.FirstDigit()) + " thousand";

            if (value.Digit(2).IsZero())
                return childPrinters.First()
                                    .Print(value.FirstDigit()) + " thousand and " + GetHundredsTextFor(value);

            return childPrinters.First().Print(value.FirstDigit()) + " thousand " + 
                   childPrinters.Last().Print(value.LastDigitsStartingAt(3));
        }

        private string GetHundredsTextFor(Number value)
        {
            if (value.Digit(3).IsZero())
                return childPrinters.First().Print(value.LastDigit());

            return childPrinters[1].Print(value.LastDigitsStartingAt(2));
        }

        public void Add(IPrintNumbers childPrinter)
        {
            childPrinters.Add(childPrinter);
        }
    }
}