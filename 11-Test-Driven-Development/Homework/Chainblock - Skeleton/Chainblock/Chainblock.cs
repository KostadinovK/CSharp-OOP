using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> byId;

        public Chainblock()
        {
            byId = new Dictionary<int, ITransaction>();
        }

        public int Count => byId.Count;
        public void Add(ITransaction tx)
        {
            if (byId.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException();
            }

            byId.Add(tx.Id, tx);
        }

        public bool Contains(ITransaction tx)
        {
            return byId.ContainsValue(tx);
        }

        public bool Contains(int id)
        {
            return byId.ContainsKey(id);
        }

        public void RemoveTransactionById(int id)
        {
            if (!byId.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            byId.Remove(id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!byId.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            var t = byId[id];
            t.Status = newStatus;
        }

        public ITransaction GetById(int id)
        {
            if (!byId.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return byId[id];
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var result = byId.Values.Where(t => t.Status == status).OrderByDescending(t => t.Amount);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var result = byId.Values.Where(t => t.Status == status).Select(t => t.From);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var result = byId.Values.Where(t => t.Status == status).Select(t => t.To);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return byId.Values.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var result = byId.Values.Where(t => t.From == sender).OrderByDescending(t => t.Amount);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var result = byId.Values.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return byId.Values.Where(t => t.Status == status && t.Amount <= amount);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var result = byId.Values.Where(t => t.From == sender && t.Amount >= amount)
                .OrderByDescending(t => t.Amount);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = byId.Values.Where(t => t.To == receiver && t.Amount > lo && t.Amount <= hi)
                .OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return byId.Values.Where(t => t.Amount >= lo && t.Amount <= hi);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var kvp in byId)
            {
                yield return kvp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
