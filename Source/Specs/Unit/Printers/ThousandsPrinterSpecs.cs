using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(SingleDigitPrinter))]
    public class given_exact_multiples_of_1000_when_converting
    {
        Establish context = () =>
            {
                printer = new ThousandsPrinter();
                printer.Add(new SingleDigitPrinter());
                printer.Add(new TensPrinter(new SingleDigitPrinter()));
                printer.Add(new HundredsPrinter(new TensPrinter(new SingleDigitPrinter())));
            }; 

        Because of = () => { };

        It the_text_one_thousand_is_returned = () => printer.Print(new Number(1000)).ShouldEqual("one thousand");
        It the_text_two_thousand_is_returned = () => printer.Print(new Number(2000)).ShouldEqual("two thousand");

        private static ThousandsPrinter printer;
    }

    [Subject(typeof(SingleDigitPrinter))]
    public class given_exact_multiples_of_1000_with_remainders_when_converting
    {
        Establish context = () =>
            {
                printer = new ThousandsPrinter();
                printer.Add(new SingleDigitPrinter());
                printer.Add(new TensPrinter(new SingleDigitPrinter()));
                var hundredsPrinter = new HundredsPrinter();
                hundredsPrinter.Add(new SingleDigitPrinter());
                hundredsPrinter.Add(new TensPrinter(new SingleDigitPrinter()));
                printer.Add(hundredsPrinter);
            }; 

        Because of = () => { };

        It the_text_one_thousand_one_hundred_and_fify_is_returned = () => printer.Print(new Number(1150)).ShouldEqual("one thousand one hundred and fifty");
        It the_text_two_thousand_and_twenty_one_is_returned = () => printer.Print(new Number(2021)).ShouldEqual("two thousand and twenty one");
        It the_text_two_thousand_and_one_is_returned = () => printer.Print(new Number(2001)).ShouldEqual("two thousand and one");

        private static ThousandsPrinter printer;
    }

    internal class ThousandsPrinter : IPrintNumbers
    {
        IList<IPrintNumbers> childPrinters = new List<IPrintNumbers>();

        public string Print(Number value)
        {
            if (value.IsExactMultipleOf(1000))
                return childPrinters.First().Print(value.FirstDigit()) + " thousand";

            if (value.Digit(2).IsZero())
            {
                if (value.Digit(3).IsZero())
                {
                    return childPrinters.First().Print(value.FirstDigit()) + " thousand and " +
                           childPrinters.First().Print(value.LastDigit());
                }
                return childPrinters.First().Print(value.FirstDigit()) + " thousand and " +
                       childPrinters[1].Print(value.LastDigitsStartingAt(2));
            }

            return childPrinters.First().Print(value.FirstDigit()) + " thousand " + 
                   childPrinters.Last().Print(value.LastDigitsStartingAt(3));
        }

        public void Add(IPrintNumbers childPrinter)
        {
            childPrinters.Add(childPrinter);
        }
    }
}