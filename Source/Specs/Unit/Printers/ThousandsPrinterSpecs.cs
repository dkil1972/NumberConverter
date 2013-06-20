using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.NumberStrategy;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
    [Subject(typeof(SingleDigitPrinter))]
    public class given_exact_multiples_of_1000_when_converting
    {
        Establish context = () =>
            {
                printer = new ThousandsPrinter();
                printer.Add(NumberSize.Ones, new SingleDigitPrinter());
                printer.Add(NumberSize.Tens, new TensPrinter(new SingleDigitPrinter()));
                printer.Add(NumberSize.Hundreds, new HundredsPrinter(new TensPrinter(new SingleDigitPrinter())));
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
                printer.Add(NumberSize.Ones, new SingleDigitPrinter());
                printer.Add(NumberSize.Tens, new TensPrinter(new SingleDigitPrinter()));
                var hundredsPrinter = new HundredsPrinter();
                hundredsPrinter.Add(new SingleDigitPrinter());
                hundredsPrinter.Add(new TensPrinter(new SingleDigitPrinter()));
                printer.Add(NumberSize.Hundreds, hundredsPrinter);
            }; 

        Because of = () => { };

        It the_text_one_thousand_one_hundred_and_fify_is_returned = () => printer.Print(new Number(1150)).ShouldEqual("one thousand one hundred and fifty");
        It the_text_two_thousand_and_twenty_one_is_returned = () => printer.Print(new Number(2021)).ShouldEqual("two thousand and twenty one");
        It the_text_two_thousand_and_one_is_returned = () => printer.Print(new Number(2001)).ShouldEqual("two thousand and one");
        It the_text_ten_thousand_five_hundred_and_three_is_returned = () => printer.Print(new Number(10503)).ShouldEqual("ten thousand five hundred and three");
        It the_text_two_hundred_thousand_five_hundred_and_three_is_returned = () => printer.Print(new Number(200503)).ShouldEqual("two hundred thousand five hundred and three");
        It the_text_two_hundred_thousand_and_thirty_three_is_returned = () => printer.Print(new Number(200033)).ShouldEqual("two hundred thousand and thirty three");
        It the_text_ten_thousand_and_thirty_three_is_returned = () => printer.Print(new Number(10033)).ShouldEqual("ten thousand and thirty three");
        It the_text_ten_thousand_and_three_is_returned = () => printer.Print(new Number(10003)).ShouldEqual("ten thousand and three");
        It the_text_ten_thousand_is_returned = () => printer.Print(new Number(10000)).ShouldEqual("ten thousand");

        private static ThousandsPrinter printer;
    }
}