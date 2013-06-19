using NumberConverter.Models;
using NumberConverter.Models.Printers;
using NumberConverter.Models.Specifications;
using SpecSalad;

namespace Tests.Roles
{
    public class NumbersMan : ApplicationRole
    {
        private int _value;

        public void Store(int value)
        {
            _value = value;
        }

        public string Convert()
        {
            return new Number(new SingleDigitPrinter()).Convert(_value);
        }
         
    }
}