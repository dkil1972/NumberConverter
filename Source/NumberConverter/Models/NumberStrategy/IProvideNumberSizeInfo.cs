namespace NumberConverter.Models.NumberStrategy
{
    public interface IProvideNumberSizeInfo
    {
        NumberSize GetSize();
        Number NumberOfMultiples();
    }
}