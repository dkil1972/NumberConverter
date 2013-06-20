using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(HundredsPrinter))]
    public class given_numbers_ending_in_zeros_when_converting
    {
        Establish context = () =>
            {
                printer = new HundredsPrinter();
                printer.Add(new SingleDigitPrinter());
                printer.Add(new TensPrinter());
            }; 

        Because of = () => { };

        It the_text_one_hundred_is_returned = () => printer.Print(new Number(100)).ShouldEqual("one hundred");
        It the_text_two_hundred_is_returned = () => printer.Print(new Number(200)).ShouldEqual("two hundred");

        private static HundredsPrinter printer;
    }

    [Subject(typeof(HundredsPrinter))]
    public class given_numbers_that_are_multiples_of_100_with_remainders_when_converting
    {
        Establish context = () =>
            {
                printer = new HundredsPrinter();
                printer.Add(new SingleDigitPrinter());
                printer.Add(new TensPrinter(new SingleDigitPrinter()));
            }; 

        Because of = () => { };

        It the_text_one_hundred_and_one_is_returned = () => printer.Print(new Number(101)).ShouldEqual("one hundred and one");
        It the_text_two_hundred_and_twenty_five_is_returned = () => printer.Print(new Number(225)).ShouldEqual("two hundred and twenty five");

        private static HundredsPrinter printer;
    }
}