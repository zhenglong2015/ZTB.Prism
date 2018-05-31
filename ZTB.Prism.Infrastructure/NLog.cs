using NLog;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTB.Prism.Infrastructure
{
    public class LogHelper : ILoggerFacade
    {
        /// <summary>
        /// Log实例
        /// </summary>
        static readonly Logger Logger;
        static LogHelper()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public void Log(string message, Category category, Priority priority)
        {
            if (string.IsNullOrEmpty(message))
                return;

            switch (category)
            {
                case Category.Debug:
                    this.Debug(message);
                    break;
                case Category.Exception:
                    this.Error(message);
                    break;
                case Category.Info:
                    this.Info(message);
                    break;
                case Category.Warn:
                    this.Fatal(message);
                    break;
            }
        }


        void Debug(string message) { Logger.Debug(message); }

        void Info(string message) { Logger.Info(message); }

        void Error(string message) { Logger.Error(message); }

        void Fatal(string message) { Logger.Fatal(message); }

    }
}
