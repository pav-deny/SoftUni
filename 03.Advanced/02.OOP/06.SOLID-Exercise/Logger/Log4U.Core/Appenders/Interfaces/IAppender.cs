using Log4U.Core.Enums;
using Log4U.Core.Models.Interfaces;

namespace Log4U.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        public uint Counter { get; set; }
        public ILayout Layout { get; set; }
        internal Severity Severity { get; set; }

        internal bool IsProperSeverity(Severity severity)
        {
            throw new NotImplementedException();
        }

       internal void Append(IMessage message);
    }
}
