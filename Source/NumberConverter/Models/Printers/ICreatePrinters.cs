namespace NumberConverter.Models.Printers
{
    public interface ICreatePrinters
    {
        IPrintNumbers CreateFrom(Number value);
    }
}