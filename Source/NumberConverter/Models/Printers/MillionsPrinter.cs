using System.Collections.Generic;
using NumberConverter.Models.NumberStrategy;

namespace NumberConverter.Models.Printers
{
    public class MillionsPrinter : IPrintNumbers
    {
        private readonly IDictionary<NumberSize, IPrintNumbers> childPrinters = new Dictionary<NumberSize, IPrintNumbers>();

        public void Add(NumberSize size, IPrintNumbers childPrinter)
        {
            childPrinters.Add(size, childPrinter);
        }

        public string Print(Number value)
        {
            var millionsDetail = value.GetNumberSize();
            if (value.IsExactMultipleOf(1000000))
                return childPrinters[millionsDetail.GetSize()].Print(millionsDetail.NumberOfMultiples()) + " million";

            var toReturn = childPrinters[millionsDetail.GetSize()].Print(millionsDetail.NumberOfMultiples()) + " million " +
                           childPrinters[NumberSize.Thousands].Print(value.ExtractThousands());

            return toReturn;
        }
    }
}