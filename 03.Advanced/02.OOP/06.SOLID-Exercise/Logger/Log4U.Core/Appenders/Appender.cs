using Log4U.Core.Appenders.Interfaces;
using Log4U.Core.Enums;
using Log4U.Core.Models.Interfaces;

namespace Log4U.Core.Appenders
{
    internal abstract class Appender : IAppender
    {
        public uint Counter { get; set; }
        public ILayout Layout { get; set; }
        public Severity Severity { get; set; }

        public abstract void Append(IMessage message);

        public bool IsProperSeverity(IMessage message)
        {
            return Severity <= message.Severity;
        }

        public override string ToString()
        {
            return $"Appender type" +
                    "Layout type:" +
                    "Report level:" +
                    "Reported Message:";
        }
    }
}
