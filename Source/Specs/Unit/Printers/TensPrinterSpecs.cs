using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(TensPrinter))]
    public class given_a_number_less_than_twenty_when_converting
    {
        Establish context = () => { printer = new TensPrinter(); }; 

        Because of = () => { };

        It the_text_representation_of_ten_is_returned = () => printer.Print(new Number(10)).ShouldEqual("ten");
        It the_text_representation_of_thirteen_is_returned = () => printer.Print(new Number(13)).ShouldEqual("thirteen");

        private static IPrintNumbers printer;
    }

    [Subject(typeof(TensPrinter))]
    public class given_the_number_22_when_converting
    {
        Establish context = () =>
            {
                printer = new TensPrinter();
                printer.Add(new SingleDigitPrinter());
            }; 

        Because of = () => { };

        It the_text_representation_of_twenty_two_is_returned = () => printer.Print(new Number(22)).ShouldEqual("twenty two");
        It the_text_representation_of_thirty_five_is_returned = () => printer.Print(new Number(35)).ShouldEqual("thirty five");
        It the_text_representation_of_ninety_nine_is_returned = () => printer.Print(new Number(99)).ShouldEqual("ninety nine");

        private static TensPrinter printer;
    }
}