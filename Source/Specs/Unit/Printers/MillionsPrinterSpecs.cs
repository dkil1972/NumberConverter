using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.NumberStrategy;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit.Printers
{
//    [Subject(typeof(MillionsPrinter))]
//    public class given_exact_multiples_of_1000000_when_converting
//    {
//        Establish context = () =>
//            {
//                printer = new ThousandsPrinter();
//                printer.Add(NumberSize.Ones, new SingleDigitPrinter());
//                printer.Add(NumberSize.Tens, new TensPrinter(new SingleDigitPrinter()));
//                printer.Add(NumberSize.Hundreds,  new HundredsPrinter(new TensPrinter(new SingleDigitPrinter())));
//            }; 
//
//        Because of = () => { };
//
//        It the_text_one_thousand_is_returned = () => printer.Print(new Number(1000)).ShouldEqual("one thousand");
//        It the_text_two_thousand_is_returned = () => printer.Print(new Number(2000)).ShouldEqual("two thousand");
//
//        private static ThousandsPrinter printer;
//    }
}