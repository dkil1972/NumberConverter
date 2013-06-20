using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.NumberStrategy;

namespace NumberConverter.Specs.Unit.NumberStrategy
{
    [Subject(typeof(Thousands))]
    public class given_a_number_with_four_digits_when_getting_size
    {
        Establish context = () => { thousands = new Thousands(new Number(1003)); };

        Because of = () => { result = thousands.GetSize(); };

        It returns_number_size_in_the_ones = () => result.ShouldEqual(NumberSize.Ones);

        private static NumberSize result;
        private static Thousands thousands;
    }

    [Subject(typeof(Thousands))]
    public class given_a_number_with_five_digits_when_getting_size
    {
        Establish context = () => { thousands = new Thousands(new Number(10348)); };

        Because of = () => { result = thousands.GetSize(); };

        It returns_number_size_in_the_tens = () => result.ShouldEqual(NumberSize.Tens);

        private static NumberSize result;
        private static Thousands thousands;
    }

    [Subject(typeof(Thousands))]
    public class given_a_number_with_six_digits_when_getting_size
    {
        Establish context = () => { thousands = new Thousands(new Number(103487)); };

        Because of = () => { result = thousands.GetSize(); };

        It returns_number_size_in_the_hundreds = () => result.ShouldEqual(NumberSize.Hundreds);

        private static NumberSize result;
        private static Thousands thousands;
    }

    [Subject(typeof(Thousands))]
    public class given_a_number_with_five_digits_when_getting_multiples_of
    {
        Establish context = () => { thousands = new Thousands(new Number(10348)); };

        Because of = () => { result = thousands.NumberOfMultiples(); };

        It returns_first_two_digits = () => result.UnderlyingValue.ShouldEqual(10);

        private static Number result;
        private static Thousands thousands;
    }

    [Subject(typeof(Thousands))]
    public class given_a_number_with_six_digits_when_getting_multiples_of
    {
        Establish context = () => { thousands = new Thousands(new Number(113480)); };

        Because of = () => { result = thousands.NumberOfMultiples(); };

        It returns_first_three_digits = () => result.UnderlyingValue.ShouldEqual(113);

        private static Number result;
        private static Thousands thousands;
    }
}