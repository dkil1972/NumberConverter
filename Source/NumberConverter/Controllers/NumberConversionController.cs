using System.Web.Mvc;
using NumberConverter.Models;
using NumberConverter.Models.Printers;

namespace NumberConverter.Controllers
{
    public class NumberConversionController : Controller
    {
        private readonly ICreatePrinters printerFactory;

        public NumberConversionController() : this(new PrinterFactory())
        {
            
        }
        public NumberConversionController(ICreatePrinters printerFactory)
        {
            this.printerFactory = printerFactory;
        }

        public ActionResult Convert(int value)
        {
            var numberToConvert = new Number(value);
            ViewData["ConvertedValue"] = printerFactory.CreateFrom(numberToConvert).Print(numberToConvert);
            return View();
        }
    }
}
