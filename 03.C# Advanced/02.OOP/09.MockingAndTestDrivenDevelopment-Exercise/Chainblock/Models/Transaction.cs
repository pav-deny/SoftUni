using Chainblock.Contracts;
using Chainblock.ExceptionMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException(TransactionExceptionMessages.IdValueNonPositive);

                id = value;
            }
        }
        public TransactionStatus Status { get; set; }
        public string From
        {
            get => from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(TransactionExceptionMessages.FromValueNullOrWhiteSpace);

                from = value;
            }
        }
        public string To
        {
            get => to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(TransactionExceptionMessages.ToValueNullOrWhiteSpace);

                to = value;
            }
        }
        public double Amount
        {
            get => amount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException(TransactionExceptionMessages.AmountValueNonPositive);

                amount = value;
            }
        }


    }
}
