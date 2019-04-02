using System;
using INStock.Contracts;

namespace INStock.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            var productLabel = "SSD";
            var productPrice = 12.33m;
            var productQuantity = 3;

            IProduct product = new Product(productLabel, productPrice, productQuantity);

            Assert.AreEqual(productLabel, product.Label);
            Assert.AreEqual(productPrice, product.Price);
            Assert.AreEqual(productQuantity, product.Quantity);
        }
        [Test]
        public void ConstructorNullLabelShouldThrowArgumentNullException()
        {
            string productLabel = null;
            var productPrice = 12.33m;
            var productQuantity = 3;

            Assert.Throws<ArgumentNullException>(() => new Product(productLabel, productPrice, productQuantity));

        }
        [Test]
        public void ConstructorInvalidPriceShouldThrowArgumentException()
        {
            string productLabel = "SSD";
            var productPrice = -12.33m;
            var productQuantity = 3;

            Assert.Throws<ArgumentException>(() => new Product(productLabel, productPrice, productQuantity));

        }
        [Test]
        public void ConstructorInvalidQuantityShouldThrowArgumentException()
        {
            string productLabel = "SSD";
            var productPrice = 12.33m;
            var productQuantity = -3;

            Assert.Throws<ArgumentException>(() => new Product(productLabel, productPrice, productQuantity));

        }
        [Test]
        public void CompareToShouldReturn1WhenComparingProductAsciiCodes()
        {
            var firstProductLabel = "ZSD";
            var secondProductLabel = "AAS";
            var productPrice = 12.33m;
            var productQuantity = 3;

            var firstProduct = new Product(firstProductLabel, productPrice, productQuantity);
            var secondProduct = new Product(secondProductLabel, productPrice, productQuantity);

            var actualResult = firstProduct.CompareTo(secondProduct);
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}