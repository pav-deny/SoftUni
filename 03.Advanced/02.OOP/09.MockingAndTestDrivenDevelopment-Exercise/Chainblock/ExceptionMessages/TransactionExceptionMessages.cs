using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.ExceptionMessages
{
    public static class TransactionExceptionMessages
    {
        public const string IdValueNonPositive = "Id should be greater than 0";
        public const string FromValueNullOrWhiteSpace = "Invalid from";
        public const string ToValueNullOrWhiteSpace = "Invalid to";
        public const string AmountValueNonPositive = "Invalid to";
    }
}
