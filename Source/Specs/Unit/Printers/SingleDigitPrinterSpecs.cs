using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(SingleDigitPrinter))]
    public class given_a_single_digit_when_printing
    {
        Establish context = () =>
                                {
                                    printer = new SingleDigitPrinter();
                                };

        Because of = () => { };

        It one_is_returned_for_1 = () => printer.Print(new Number(1)).ShouldEqual("one");
        It nine_is_returned_for_9 = () => printer.Print(new Number(9)).ShouldEqual("nine");

        private static SingleDigitPrinter printer;
    }
    
    [Subject(typeof(SingleDigitPrinter))]
    public class given_zero_value_when_printing
    {
        Establish context = () =>
                                {
                                    printer = new SingleDigitPrinter();
                                };

        Because of = () => { };

        It an_empty_string_is_returned = () => printer.Print(new Number(0)).ShouldEqual("");

        private static SingleDigitPrinter printer;
    }
}