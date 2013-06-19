using Machine.Specifications;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(SingleDigitPrinter))]
    public class given_a_number_less_than_twenty_when_converting
    {
        Establish context = () => { printer = new TensPrinter(); }; 

        Because of = () => { };

        It the_text_representation_of_ten_is_returned = () => printer.Print(10).ShouldEqual("ten");
        It the_text_representation_of_thirteen_is_returned = () => printer.Print(13).ShouldEqual("thirteen");

        private static IPrintNumbers printer;
    }

    [Subject(typeof(SingleDigitPrinter))]
    public class given_the_number_22_when_converting
    {
        Establish context = () =>
            {
                printer = new TensPrinter();
                printer.Add(new SingleDigitPrinter());
            }; 

        Because of = () => { };

        It the_text_representation_of_twenty_two_is_returned = () => printer.Print(22).ShouldEqual("twenty two");
        It the_text_representation_of_thirty_five_is_returned = () => printer.Print(35).ShouldEqual("thirty five");
        It the_text_representation_of_ninety_nine_is_returned = () => printer.Print(99).ShouldEqual("ninety nine");

        private static TensPrinter printer;
    }
}