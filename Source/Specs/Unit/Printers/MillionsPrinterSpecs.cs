using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(MillionsPrinter))]
    public class given_exact_multiples_of_a_million_when_converting
    {
        Establish context = () => { printer = TestFactory.GetMillionsPrinter(); }; 

        Because of = () => { };

        It the_text_one_million = () => printer.Print(new Number(1000000)).ShouldEqual("one million");
        It the_text_twenty_million_is_returned = () => printer.Print(new Number(20000000)).ShouldEqual("twenty million");
        It the_text_two_hundred_million_is_returned = () => printer.Print(new Number(200000000)).ShouldEqual("two hundred million");

        private static MillionsPrinter printer;
    }

    [Subject(typeof(MillionsPrinter))]
    public class given_a_multiple_of_a_million_with_a_remainder_when_printing_millions
    {
        Establish context = () => { printer = TestFactory.GetMillionsPrinter(); }; 

        Because of = () => { };

        It the_text_one_million_one_hundred_and_fifty_thousand_one_hundred_and_fifteen_is_returned = 
            () => printer.Print(new Number(1150115)).ShouldEqual("one million one hundred and fifty thousand one hundred and fifteen");
        It the_text_ten_million_one_hundred_and_fifty_thousand_one_hundred_and_fifteen_is_returned = 
            () => printer.Print(new Number(10150115)).ShouldEqual("ten million one hundred and fifty thousand one hundred and fifteen");
        It the_text_fifteen_million_one_hundred_and_fifty_thousand_one_hundred_and_fifteen_is_returned = 
            () => printer.Print(new Number(15150115)).ShouldEqual("fifteen million one hundred and fifty thousand one hundred and fifteen");
        It the_text_one_hundred_million_one_hundred_and_fifty_thousand_one_hundred_and_fifteen_is_returned = 
            () => printer.Print(new Number(100150115)).ShouldEqual("one hundred million one hundred and fifty thousand one hundred and fifteen");
        It the_text_nine_hundred_and_ninety_nine_million_nine_hundred_and_ninety_nine_thousand_nine_hundred_and_ninety_nine_is_returned = 
            () => printer.Print(new Number(999999999)).ShouldEqual("nine hundred and ninety nine million nine hundred and ninety nine thousand nine hundred and ninety nine");

        private static MillionsPrinter printer;
    }
}