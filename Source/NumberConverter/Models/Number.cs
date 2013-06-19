namespace NumberConverter.Models
{
    public class Number
    {
        public Number(int underlyingValue)
        {
            this.UnderlyingValue = underlyingValue;
        }

        public int UnderlyingValue { get; set; }

        public bool IsExactMultipleOf(int multiple)
        {
            return UnderlyingValue%multiple == 0;
        }

        public Number FirstDigit()
        {
            return new Number(int.Parse(UnderlyingValue.ToString()[0].ToString()));
        }

        public Number LastDigit()
        {
            var valueAsString = UnderlyingValue.ToString();
            return new Number(int.Parse(valueAsString[valueAsString.Length - 1].ToString()));
        }

        public Number Digit(int at)
        {
            return new Number(int.Parse(UnderlyingValue.ToString()[at - 1].ToString()));
        }

        public Number LastDigitsStartingAt(int from)
        {
            return new Number(int.Parse(UnderlyingValue.ToString().Substring(UnderlyingValue.ToString().Length - from)));
        }

        public bool IsZero()
        {
            return UnderlyingValue == 0;
        }

        public bool BetweenTenAndTwenty()
        {
            return UnderlyingValue >= 10 && UnderlyingValue < 20;
        }
    }
}