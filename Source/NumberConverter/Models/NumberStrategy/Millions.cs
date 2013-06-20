namespace NumberConverter.Models.NumberStrategy
{
    public class Millions : IProvideNumberSizeInfo
    {
        private readonly Number number;

        public Millions(Number number)
        {
            this.number = number;
        }

        public NumberSize GetSize()
        {
            if(number.DigitCount == 8)
                return NumberSize.Tens;

            if(number.DigitCount == 9)
                return NumberSize.Hundreds;

            return NumberSize.Ones;
        }

        public Number NumberOfMultiples()
        {
            if (number.DigitCount == 8)
                return number.FirstDigitsUpto(2);

            if (number.DigitCount == 9)
                return number.FirstDigitsUpto(3);

            return number.FirstDigit();
        }
    }
}