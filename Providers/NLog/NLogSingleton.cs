using NLog;
using NLog.Web;

namespace ExamMeAI.Providers.NLog
{
    public sealed class NLogSingleton
    {
        private static NLogSingleton _instance = null;

        public static NLogSingleton GetInstance()
        {
            if (_instance == null)
            {
                return _instance = new NLogSingleton();
            }
            return _instance;
        }

        public Logger NlogInit()
        {
            return NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }
    }
}
