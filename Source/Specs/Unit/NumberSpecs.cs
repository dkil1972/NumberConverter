using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Specs.Unit
{
    [Subject(typeof(Number))]
    public class given_the_number_1_when_converting_to_text
    {
        Establish context = () =>
                                {
                                    number = new Number(new SingleDigitPrinter());
                                };

        Because of = () => { result = number.Convert(1); };

        It returns_the_text_one = () => result.ShouldEqual("one");

        private static string result;
        private static Number number;
    }
}