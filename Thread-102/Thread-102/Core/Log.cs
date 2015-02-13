using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Thread_102.Core
{
    public class Log
    {
        private static readonly log4net.ILog logTick = log4net.LogManager.GetLogger("tick_logger");

        public static void Tick(string message)
        {
            logTick.Info(message);
        }
    }
}
