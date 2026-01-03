using ExamMeAI.Interfaces;
using Humanizer.DateTimeHumanizeStrategy;

namespace ExamMeAI.Strategies
{
    public class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            _strategy.Execute();
        }
    }
}
