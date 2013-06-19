using SpecSalad;

namespace Tests.Tasks
{
    public class Convert : ApplicationTask
    {
        public override object Perform_Task()
        {
            Role.Store(int.Parse(Details.Value_Of("the_number")));

            return null;
        }
    }
}