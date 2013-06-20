using NumberConverter.Models.NumberStrategy;

namespace NumberConverter.Models.Printers
{
    public class PrinterFactory : ICreatePrinters
    {
        public IPrintNumbers CreateFrom(Number value)
        {
            var singleDigitPrinter = new SingleDigitPrinter();
            var tensPrinter = new TensPrinter();
            tensPrinter.Add(singleDigitPrinter);
            
            var hundredsPrinter = new HundredsPrinter();
            hundredsPrinter.Add(singleDigitPrinter);
            hundredsPrinter.Add(tensPrinter);

            var thousandsPrinter = new ThousandsPrinter();
            thousandsPrinter.Add(NumberSize.Ones, singleDigitPrinter);
            thousandsPrinter.Add(NumberSize.Tens, tensPrinter);
            thousandsPrinter.Add(NumberSize.Hundreds, hundredsPrinter);

            var millionsPrinter = new MillionsPrinter();
            millionsPrinter.Add(NumberSize.Ones, singleDigitPrinter);
            millionsPrinter.Add(NumberSize.Tens, tensPrinter);
            millionsPrinter.Add(NumberSize.Hundreds, hundredsPrinter);
            millionsPrinter.Add(NumberSize.Thousands, thousandsPrinter);

            if (value.IsTens)
                return tensPrinter;

            if (value.IsHundreds)
                return hundredsPrinter;

            if (value.IsThousands)
                return thousandsPrinter;

            if (value.IsMillions)
                return millionsPrinter;

            return singleDigitPrinter;
        }
    }
}