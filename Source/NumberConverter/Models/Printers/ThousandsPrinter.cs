using System.Collections.Generic;
using NumberConverter.Models.NumberStrategy;

namespace NumberConverter.Models.Printers
{
    public class ThousandsPrinter : IPrintNumbers
    {
        IDictionary<NumberSize, IPrintNumbers> childPrinters = new Dictionary<NumberSize, IPrintNumbers>();

        public string Print(Number value)
        {
            var thousandsDetail = value.GetNumberSize();
            if (value.IsExactMultipleOf(1000))
                return childPrinters[thousandsDetail.GetSize()].Print(thousandsDetail.NumberOfMultiples()) + " thousand";

            return GetTextForValueWithRemainder(value, thousandsDetail);
        }

        private string GetTextForValueWithRemainder(Number value, IProvideNumberSizeInfo thousandsDetail)
        {
            var toReturn = childPrinters[thousandsDetail.GetSize()].Print(thousandsDetail.NumberOfMultiples()) + " thousand";

            if (value.ContainsHundreds())
                toReturn += " " + childPrinters[NumberSize.Hundreds].Print(value.ExtractHundreds());
            else if (value.ContainsTens())
                toReturn += " and " + childPrinters[NumberSize.Tens].Print(value.LastDigitsFrom(3));
            else
                toReturn += " and " + childPrinters[NumberSize.Ones].Print(value.LastDigit());

            return toReturn;
        }

        public void Add(NumberSize key, IPrintNumbers value)
        {
            childPrinters.Add(key, value);
        }
    }
}