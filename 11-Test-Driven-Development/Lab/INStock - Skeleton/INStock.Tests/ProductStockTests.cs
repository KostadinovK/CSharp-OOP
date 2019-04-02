using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using INStock.Contracts;

namespace INStock.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class ProductStockTests
    {
        private ProductStock productStock;
        private Product product;
        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock();
            product = new Product("SSD", 23.33m, 2);
        }

        [Test]
        public void Constructor_ShouldInitializeListCorrectly()
        {
            var expectedCount = 0;
            var actualCount = productStock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Add_ShouldIncreaseCountCorrectly()
        {
            productStock.Add(product);

            var expectedCount = 1;
            var actualCount = productStock.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Add_SameProductAgainShouldThrowInvalidOperationException()
        {
            productStock.Add(product);

            Assert.Throws<InvalidOperationException>(() => productStock.Add(product));
        }
        [Test]
        public void Get_AtInvalidIndexShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => product = (Product)productStock[33]);
        }
        [Test]
        public void Get_AtValidIndexShouldWorkCorrectly()
        {
            productStock.Add(product);

            var expectedProduct = productStock[0];

            Assert.AreSame(expectedProduct, product);
        }
        [Test]
        public void Set_AtInvalidIndexShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock[22] = product);
        }
        [Test]
        public void Set_AtValidIndexShouldWorkCorrectly()
        {
            productStock.Add(product);
            productStock[1] = product;

            Assert.AreEqual(product.Label, productStock[0].Label);
            Assert.AreEqual(product.Price, productStock[0].Price);
            Assert.AreEqual(product.Quantity, productStock[0].Quantity);
        }
        [Test]
        public void Contains_NonExistingProductShouldReturnFalse()
        {
            Assert.IsFalse(productStock.Contains(product));
        }

        [Test]
        public void Contains_ExistingProductShouldReturnTrue()
        {
            productStock.Add(product);

            Assert.IsTrue(productStock.Contains(product));
        }

        [Test]
        public void Remove_NonExistingProductShouldReturnFalse()
        {
            Assert.IsFalse(productStock.Remove(product));
        }

        [Test]
        public void Remove_ExistingProductShouldReturnTrue()
        {
            productStock.Add(product);

            Assert.IsTrue(productStock.Remove(product));
            Assert.AreEqual(0, productStock.Count);
        }

        [Test]
        public void Find_AtInvalidIndexShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(22));
        }

        [Test]
        public void Find_AtValidIndexShouldWorkCorrectly()
        {
            productStock.Add(product);

            var actual = productStock.Find(0);
            var expected = product;

            Assert.AreSame(expected, actual);
        }

        [Test]
        public void FindByLabel_WithNonExistingLabelShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => productStock.FindByLabel("SSD"));
        }

        [Test]
        public void FindByLabel_WithExistingLabelShouldWorkCorrectly()
        {
            productStock.Add(product);

            var p = productStock.FindByLabel(product.Label);

            Assert.AreSame(product, p);
        }

        [Test]
        public void FindMostExpensiveProduct_WhenCollectionIsEmptySHouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => productStock.FindMostExpensiveProduct());
        }

        [Test]
        public void FindMostExpensiveProduct_ShouldWorkCorrectly()
        {
            IProduct expected = new Product("Costly", 122m, 2);
            productStock.Add(product);
            productStock.Add(expected);

            var actual = productStock.FindMostExpensiveProduct();

            Assert.AreSame(expected, actual);
        }

        [Test]
        public void FindAllInRange_ShouldReturnEmptyEnumeration()
        {
            var actual = productStock.FindAllInRange(10, 22);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void FindAllInRange_ShouldReturnProductsCorrectly()
        {
            IProduct product2 = new Product("HDD", 100, 2);
            IProduct product3 = new Product("Phone", 200, 2);

            productStock.Add(product);
            productStock.Add(product2);
            productStock.Add(product3);

            IEnumerable<IProduct> expected = new List<IProduct>{product2, product};
            IEnumerable<IProduct> actual = productStock.FindAllInRange(1, 100);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindAllByPrice_ShouldReturnEmptyEnumeration()
        {
            var actual = productStock.FindAllByPrice(10);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void FindAllByPrice_ShouldReturnProductsCorrectly()
        {
            IProduct product2 = new Product("HDD", 100, 2);
            IProduct product3 = new Product("Phone", 100, 2);

            productStock.Add(product);
            productStock.Add(product2);
            productStock.Add(product3);

            IEnumerable<IProduct> expected = new List<IProduct> { product2, product3 };
            IEnumerable<IProduct> actual = productStock.FindAllByPrice(100);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnEmptyEnumeration()
        {
            var actual = productStock.FindAllByQuantity(2);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnProductsCorrectly()
        {
            IProduct product2 = new Product("HDD", 100, 2);
            IProduct product3 = new Product("Phone", 100, 21);

            productStock.Add(product);
            productStock.Add(product2);
            productStock.Add(product3);

            IEnumerable<IProduct> expected = new List<IProduct> { product, product2 };
            IEnumerable<IProduct> actual = productStock.FindAllByQuantity(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetEnumerator_ShouldReturnProductsCorrectly()
        {
            IProduct product2 = new Product("HDD", 100, 2);
            IProduct product3 = new Product("Phone", 100, 21);

            productStock.Add(product);
            productStock.Add(product2);
            productStock.Add(product3);

            IEnumerable<IProduct> expected = new List<IProduct> { product, product2, product3 };
            List<IProduct> actual = new List<IProduct>();

            foreach (var p in productStock)
            {
                actual.Add(p);
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
