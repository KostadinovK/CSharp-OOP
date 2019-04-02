using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus status;
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

        public int Id {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                id = value;
            }
        }

        public TransactionStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public string From
        {
            get { return from;}
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                from = value;
            }
        }

        public string To
        {
            get { return to;}
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                to = value;
            }
        }

        public double Amount
        {
            get { return amount;}
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
