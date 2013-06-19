using Machine.Specifications;
using NumberConverter.Models.Printers;

namespace Namespace
{
    [Subject(typeof(SingleDigitPrinter))]
    public class given_a_single_digit_when_printing
    {
        Establish context = () =>
                                {
                                    printer = new SingleDigitPrinter();
                                };

        Because of = () => { };

        It one_is_returned_for_1 = () => printer.Print(1).ShouldEqual("one");
        It nine_is_returned_for_9 = () => printer.Print(9).ShouldEqual("nine");

        private static SingleDigitPrinter printer;
    }
}