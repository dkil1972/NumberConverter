using System.Web.Mvc;
using NumberConverter.Controllers;
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
            var numberConversion = new NumberConversionController();
            var actionResult = numberConversion.Convert(_value);
            return ((ViewResult) actionResult).ViewData["ConvertedValue"].ToString();
        }
         
    }
}