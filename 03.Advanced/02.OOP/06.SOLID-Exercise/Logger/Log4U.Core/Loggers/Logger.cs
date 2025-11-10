using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.Loggers.Interfaces;
using Log4U.Core.Models;
using Log4U.Core.Models.Interfaces;

namespace Log4U.Core.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string message) => AppendAll(Severity.Info, dateTime, message);
        public void Warning(string dateTime, string message)  => AppendAll(Severity.Warning, dateTime, message);
        public void Error(string dateTime, string message) => AppendAll(Severity.Error, dateTime, message);
        public void Critical(string dateTime, string message) => AppendAll(Severity.Critical, dateTime, message);
        public void Fatal(string dateTime, string message) => AppendAll(Severity.Fatal, dateTime, message);

        internal void AppendAll(Severity severity, string dateTime, string message)
        {
            IMessage newMessage = new Message(severity, dateTime, message);

            foreach (IAppender appender in appenders)
            {
                appender.Append(newMessage);
            }
        }
    }
}