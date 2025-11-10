using Log4U.Core.Enums;
using Log4U.Core.Models.Interfaces;
using System.Globalization;

namespace Log4U.Core.Models
{
    internal class Message : IMessage
    {
        private const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";

        public Message(Severity severity, string datTime, string message)
        {
            DateTime = ValidateDateTime(DateTimeFormat, datTime);

            this.Severity = severity;
            this.Text = message;
        }

        public DateTime DateTime { get; }
        public string Text { get; }
        public Severity Severity { get; }

        public DateTime ValidateDateTime(string validFormat, string dateTimeStr)
        {
            if (string.IsNullOrWhiteSpace(dateTimeStr))
                throw new NullReferenceException("The date and time are empty or null. Please provide a valid DateTime string");

            DateTime result;
            bool parseSuccesfull = DateTime.TryParseExact(dateTimeStr, DateTime, validFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

            if (!parseSuccesfull)
                throw new InvalidDataException("DateTime was not valid. Try again with a corrct DateTime");

            return result;
        }
    }
}
