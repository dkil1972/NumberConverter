using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.NumberStrategy;

namespace NumberConverter.Specs.Unit.NumberStrategy
{
    [Subject(typeof(Millions))]
    public class given_a_number_with_seven_digits_when_getting_size
    {
        Establish context = () => { millions = new Millions(new Number(1187365)); };

        Because of = () => { result = millions.GetSize(); };

        It returns_number_size_in_the_ones = () => result.ShouldEqual(NumberSize.Ones);

        private static NumberSize result;
        private static Millions millions;
    }

    [Subject(typeof(Millions))]
    public class given_a_number_with_eight_digits_when_getting_size
    {
        Establish context = () => { millions = new Millions(new Number(11348652)); };

        Because of = () => { result = millions.GetSize(); };

        It returns_number_size_in_the_ones = () => result.ShouldEqual(NumberSize.Tens);

        private static NumberSize result;
        private static Millions millions;
    }

    [Subject(typeof(Millions))]
    public class given_a_number_with_nine_digits_when_getting_size
    {
        Establish context = () => { millions = new Millions(new Number(113487439)); };

        Because of = () => { result = millions.GetSize(); };

        It returns_number_size_in_the_ones = () => result.ShouldEqual(NumberSize.Hundreds);

        private static NumberSize result;
        private static Millions millions;
    }

    [Subject(typeof(Millions))]
    public class given_a_number_with_seven_digits_when_getting_number_of_multiples
    {
        Establish context = () => { millions = new Millions(new Number(2348743)); };

        Because of = () => { result = millions.NumberOfMultiples(); };

        It returns_first_digit = () => result.UnderlyingValue.ShouldEqual(2);

        private static Number result;
        private static Millions millions;
    }

    [Subject(typeof(Millions))]
    public class given_a_number_with_eight_digits_when_getting_number_of_multiples
    {
        Establish context = () => { millions = new Millions(new Number(11348743)); };

        Because of = () => { result = millions.NumberOfMultiples(); };

        It returns_first_two_digits = () => result.UnderlyingValue.ShouldEqual(11);

        private static Number result;
        private static Millions millions;
    }

    [Subject(typeof(Millions))]
    public class given_a_number_with_nine_digits_when_getting_number_of_multiples
    {
        Establish context = () => { millions = new Millions(new Number(113487439)); };

        Because of = () => { result = millions.NumberOfMultiples(); };

        It returns_first_three_digits = () => result.UnderlyingValue.ShouldEqual(113);

        private static Number result;
        private static Millions millions;
    }
}