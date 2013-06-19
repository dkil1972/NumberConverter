namespace NumberConverter.Models.Specifications
{
    public interface ISpecifyNumberValue
    {
        bool IsSatisfiedBy(int value);
    }
}