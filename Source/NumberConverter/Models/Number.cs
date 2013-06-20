using System;
using System.Collections.Generic;
using NumberConverter.Models.NumberStrategy;

namespace NumberConverter.Models
{
    public class Number
    {
        private IDictionary<int, Func<Number, IProvideNumberSizeInfo>> lengthToNumberSizeMap =
            new Dictionary<int, Func<Number, IProvideNumberSizeInfo>>
                {
                    {4, number => new Thousands(number)},
                    {5, number => new Thousands(number)},
                    {6, number => new Thousands(number)},
                    {7, number => new Millions(number)},
                    {8, number => new Millions(number)},
                    {9, number => new Millions(number)},
                };

        public Number(int underlyingValue)
        {
            this.UnderlyingValue = underlyingValue;
        }

        public int UnderlyingValue { get; set; }

        public int DigitCount
        {
            get { return UnderlyingValue.ToString().Length; }
        }

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

        public Number LastDigitsFrom(int from)
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

        public NumberSize GetSize()
        {
            if(UnderlyingValue.ToString().Length == 2 || UnderlyingValue.ToString().Length == 5 || UnderlyingValue.ToString().Length == 8)
                return NumberSize.Tens;

            if(UnderlyingValue.ToString().Length == 6)
                return NumberSize.Hundreds;

            return NumberSize.Ones;
        }

        public IProvideNumberSizeInfo GetNumberSize()
        {
            return lengthToNumberSizeMap[UnderlyingValue.ToString().Length].Invoke(this);
        }

        public Number FirstDigitsUpto(int thisDigit)
        {
            return new Number(int.Parse(UnderlyingValue.ToString().Substring(0, thisDigit)));
        }

        public bool ContainsHundreds()
        {
            if (UnderlyingValue < 100)
                return false;

            return LastDigitsFrom(3).DigitCount >= 3;
        }

        public bool ContainsTens()
        {
            if (UnderlyingValue < 10)
                return false;

            return LastDigitsFrom(2).DigitCount >= 2;
        }
    }
}