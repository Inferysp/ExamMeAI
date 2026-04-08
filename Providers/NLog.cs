using NLog;

namespace ExamMeAI.Providers
{
    public sealed class Log
    {
        private static Log _instance = GetInstance();
        public static readonly Logger logger = GetLogger();

        public static Log GetInstance()
        {
            if (_instance == null)
            {
                return _instance = new Log();
            }
            return _instance;
        }

        public static Logger GetLogger()
        {
            return LogManager.GetCurrentClassLogger();
        }
    }
}
