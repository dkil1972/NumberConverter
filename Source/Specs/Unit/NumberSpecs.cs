using Machine.Specifications;
using NumberConverter.Models;
using NumberConverter.Models.NumberStrategy;

namespace NumberConverter.Specs.Unit
{
    [Subject(typeof(Number))]
    public class given_a_number_less_than_100_when_checking_contains_hundreds
    {
        Establish context = () => { number = new Number(99); };

        Because of = () => { result = number.ContainsHundreds(); };

        It returns_false = () => result.ShouldBeFalse();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_a_number_over_1000_which_has_hundreds_when_checking_contains_hundreds
    {
        Establish context = () => { number = new Number(2500); };

        Because of = () => { result = number.ContainsHundreds(); };

        It returns_true = () => result.ShouldBeTrue();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_200_when_checking_is_exact_multiple
    {
        Establish context = () =>
                                {
                                    number = new Number(200);
                                };

        Because of = () => { result = number.IsExactMultipleOf(100); };

        It returns_true = () => result.ShouldBeTrue();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_125_when_checking_is_exact_multiple
    {
        Establish context = () => { number = new Number(125); };

        Because of = () => { result = number.IsExactMultipleOf(100); };

        It returns_false = () => result.ShouldBeFalse();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_125_when_getting_the_first_digit
    {
        Establish context = () => { number = new Number(125); };

        Because of = () => { result = number.FirstDigit(); };

        private It returns_1 = () => result.UnderlyingValue.ShouldEqual(1);

        private static Number result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_125_when_getting_the_last_digit
    {
        Establish context = () => { number = new Number(125); };

        Because of = () => { result = number.LastDigit(); };

        private It returns_5 = () => result.UnderlyingValue.ShouldEqual(5);

        private static Number result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_125_when_getting_the_second_digit
    {
        Establish context = () => { number = new Number(125); };

        Because of = () => { result = number.Digit(2); };

        private It returns_2 = () => result.UnderlyingValue.ShouldEqual(2);

        private static Number result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_12156_when_getting_the_last_3_digits
    {
        Establish context = () => { number = new Number(12156); };

        Because of = () => { result = number.LastDigitsFrom(3); };

        private It returns_156 = () => result.UnderlyingValue.ShouldEqual(156);

        private static Number result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_12156_when_getting_the_first_2_digits
    {
        Establish context = () => { number = new Number(12156); };

        Because of = () => { result = number.FirstDigitsUpto(2); };

        private It returns_12 = () => result.UnderlyingValue.ShouldEqual(12);

        private static Number result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_0_when_checking_is_zero
    {
        Establish context = () => { number = new Number(0); };

        Because of = () => { result = number.IsZero(); };

        private It returns_true = () => result.ShouldBeTrue();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_5_when_checking_is_zero
    {
        Establish context = () => { number = new Number(5); };

        Because of = () => { result = number.IsZero(); };

        private It returns_false = () => result.ShouldBeFalse();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_15_when_checking_between_ten_and_twenty
    {
        Establish context = () => { number = new Number(15); };

        Because of = () => { result = number.BetweenTenAndTwenty(); };

        private It returns_true = () => result.ShouldBeTrue();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_10_when_checking_between_ten_and_twenty
    {
        Establish context = () => { number = new Number(10); };

        Because of = () => { result = number.BetweenTenAndTwenty(); };

        private It returns_true = () => result.ShouldBeTrue();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_20_when_checking_between_ten_and_twenty
    {
        Establish context = () => { number = new Number(20); };

        Because of = () => { result = number.BetweenTenAndTwenty(); };

        private It returns_false = () => result.ShouldBeFalse();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_the_number_9_when_checking_between_ten_and_twenty
    {
        Establish context = () => { number = new Number(9); };

        Because of = () => { result = number.BetweenTenAndTwenty(); };

        It returns_false = () => result.ShouldBeFalse();

        private static bool result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_a_number_with_four_digits_when_getting_number_size_information
    {
        Establish context = () => { number = new Number(1003); };

        Because of = () => { result = number.GetNumberSize(); };

        It returns_size_information_for_thousands = () => result.ShouldBeOfType<Thousands>();

        private static IProvideNumberSizeInfo result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_a_number_with_five_digits_when_getting_number_size_information
    {
        Establish context = () => { number = new Number(10030); };

        Because of = () => { result = number.GetNumberSize(); };

        It returns_size_information_for_thousands = () => result.ShouldBeOfType<Thousands>();

        private static IProvideNumberSizeInfo result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_a_number_with_six_digits_when_getting_number_size_information
    {
        Establish context = () => { number = new Number(100300); };

        Because of = () => { result = number.GetNumberSize(); };

        It returns_size_information_for_thousands = () => result.ShouldBeOfType<Thousands>();

        private static IProvideNumberSizeInfo result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_a_number_with_seven_digits_when_getting_number_size_information
    {
        Establish context = () => { number = new Number(1003033); };

        Because of = () => { result = number.GetNumberSize(); };

        It returns_size_information_for_thousands = () => result.ShouldBeOfType<Millions>();

        private static IProvideNumberSizeInfo result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_a_number_with_eight_digits_when_getting_number_size_information
    {
        Establish context = () => { number = new Number(10030388); };

        Because of = () => { result = number.GetNumberSize(); };

        It returns_size_information_for_thousands = () => result.ShouldBeOfType<Millions>();

        private static IProvideNumberSizeInfo result;
        private static Number number;
    }

    [Subject(typeof(Number))]
    public class given_a_number_with_nine_digits_when_getting_number_size_information
    {
        Establish context = () => { number = new Number(100300893); };

        Because of = () => { result = number.GetNumberSize(); };

        It returns_size_information_for_thousands = () => result.ShouldBeOfType<Millions>();

        private static IProvideNumberSizeInfo result;
        private static Number number;
    }
}