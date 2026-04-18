using Log4U.Core.Enums;

namespace Log4U.Core.Models.Interfaces
{
    internal interface IMessage
    {
        public DateTime DateTime { get; }
        public string Text { get; }
        public Severity Severity { get; }
    }
}
