using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;
        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public int Count => products.Count;
        public IProduct this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return products[index];
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }

                products.Insert(index, value);
            }
        }

        public bool Contains(IProduct product)
        {
            return products.Contains(product);
        }

        public void Add(IProduct product)
        {
            if (products.Contains(product))
            {
                throw new InvalidOperationException();
            }

            products.Add(product);
        }

        public bool Remove(IProduct product)
        {
            return products.Remove(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            return products[index];
        }

        public IProduct FindByLabel(string label)
        {
            IProduct result = null;
            foreach (var product in products)
            {
                if (product.Label == label)
                {
                    result = product;
                    break;
                }
            }

            if (result == null)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return products
                .OrderByDescending(p => p.Price)
                .First();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return products.Where(p => p.Price >= lo && p.Price <= hi).OrderByDescending(p => p.Price);
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return products.Where(p => p.Price == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return products.Where(p => p.Quantity == quantity);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
