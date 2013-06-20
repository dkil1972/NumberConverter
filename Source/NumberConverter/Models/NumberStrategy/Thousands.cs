namespace NumberConverter.Models.NumberStrategy
{
    public class Thousands : IProvideNumberSizeInfo
    {
        private readonly Number number;

        public Thousands(Number number)
        {
            this.number = number;
        }

        public NumberSize GetSize()
        {
            if(number.DigitCount == 5)
                return NumberSize.Tens;

            if(number.DigitCount == 6)
                return NumberSize.Hundreds;

            return NumberSize.Ones;
        }

        public Number NumberOfMultiples()
        {
            if (number.DigitCount == 5)
                return number.FirstDigitsUpto(2);

            if (number.DigitCount == 6)
                return number.FirstDigitsUpto(3);

            return number.FirstDigit();
        }
    }
}