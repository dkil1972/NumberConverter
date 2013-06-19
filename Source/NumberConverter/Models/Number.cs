using NumberConverter.Models.Printers;

namespace NumberConverter.Models
{
    public class Number
    {
        private readonly IPrintNumbers numberPrinter;

        public Number(IPrintNumbers numberPrinter)
        {
            this.numberPrinter = numberPrinter;
        }

        public string Convert(int value)
        {
            return numberPrinter.Print(value);
        }
    }
}