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
            return new Number().Convert(_value);
        }
         
    }

    public class Number
    {
        public string Convert(int value)
        {
            return "forty two";
        }
    }
}