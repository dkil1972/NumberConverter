using NumberConverter.Models.NumberStrategy;
using NumberConverter.Models.Printers;
using NumberConverter.Specs.Unit.Printers;

namespace NumberConverter.Specs.Unit
{
    public static class TestFactory
    {
        public static MillionsPrinter GetMillionsPrinter()
        {
            var tensPrinter = new TensPrinter();
            tensPrinter.Add(new SingleDigitPrinter());

            var hundredsPrinter = new HundredsPrinter();
            hundredsPrinter.Add(new SingleDigitPrinter());
            hundredsPrinter.Add(tensPrinter);

            var thousandsPrinter = new ThousandsPrinter();
            thousandsPrinter.Add(NumberSize.Ones, new SingleDigitPrinter());
            thousandsPrinter.Add(NumberSize.Tens, tensPrinter);
            thousandsPrinter.Add(NumberSize.Hundreds, hundredsPrinter);

            var printer = new MillionsPrinter();
            printer.Add(NumberSize.Ones, new SingleDigitPrinter());
            printer.Add(NumberSize.Tens, tensPrinter);
            printer.Add(NumberSize.Hundreds, hundredsPrinter);
            printer.Add(NumberSize.Thousands, thousandsPrinter);

            return printer;
        }
    }
}