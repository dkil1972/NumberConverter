using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(PrinterFactory))]
    public class given_a_value_with_one_digit_when_creating_printers
    {
        Establish context = () => { printerFactory = new PrinterFactory(); };

        It creates_a_single_digit_printer = () => 
            printerFactory.CreateFrom(new Number(1)).ShouldBeOfType(typeof (SingleDigitPrinter));

        private static PrinterFactory printerFactory;
    }

    [Subject(typeof(PrinterFactory))]
    public class given_a_value_with_two_digits_when_creating_printers
    {
        Establish context = () => { printerFactory = new PrinterFactory(); };

        It creates_a_tens_printer = () => 
            printerFactory.CreateFrom(new Number(11)).ShouldBeOfType(typeof (TensPrinter));

        private static PrinterFactory printerFactory;
    }

    [Subject(typeof(PrinterFactory))]
    public class given_a_value_with_3_digits_when_creating_printers
    {
        Establish context = () =>
            {
                number = new Number(113);
                printerFactory = new PrinterFactory();
            };

        Because of = () => { printer = printerFactory.CreateFrom(number); };

        It creates_a_hundreds_printer = () => printer.ShouldBeOfType(typeof (HundredsPrinter));
        It prints_correct_value = () => printer.Print(number).ShouldEqual("one hundred and thirteen");

        private static PrinterFactory printerFactory;
        private static IPrintNumbers printer;
        private static Number number;
    }

    [Subject(typeof(PrinterFactory))]
    public class given_a_value_with_between_four_and_six_digits_when_creating_printers
    {
        Establish context = () =>
            {
                number = new Number(11314);
                printerFactory = new PrinterFactory();
            };

        Because of = () => { printer = printerFactory.CreateFrom(number); };

        It creates_a_thousands_printer = () => printer.ShouldBeOfType(typeof (ThousandsPrinter));
        It prints_correct_value = () => printer.Print(number).ShouldEqual("eleven thousand three hundred and fourteen");

        private static PrinterFactory printerFactory;
        private static IPrintNumbers printer;
        private static Number number;
    }

    [Subject(typeof(PrinterFactory))]
    public class given_a_value_with_between_seven_and_nine_digits_when_creating_printers
    {
        Establish context = () =>
            {
                number = new Number(11314895);
                printerFactory = new PrinterFactory();
            };

        Because of = () => { printer = printerFactory.CreateFrom(number); };

        It creates_a_thousands_printer = () => printer.ShouldBeOfType(typeof (MillionsPrinter));
        It prints_correct_value = () => printer.Print(number).ShouldEqual("eleven million three hundred and fourteen thousand eight hundred and ninety five");

        private static PrinterFactory printerFactory;
        private static IPrintNumbers printer;
        private static Number number;
    }
}