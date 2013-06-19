using SpecSalad;

namespace Tests.Tasks
{
    public class SeeTheAnswer : ApplicationTask
    {
        public override object Perform_Task()
        {
            return Role.Convert();
        }
    }
}