using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TwitterToSerialLib;

namespace TwitterToSerialTests
{
    [TestFixture]
    public class HelperTests
    {
        private int bufferSize = 10;
        
        [Test]
        public void MessageWithLengthLowerThanBufferSizeReturnsOneItem()
        {
            var msg = "lorem";
            var result = Helper.Split(msg, bufferSize);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("lorem", result[0]);
        }

        [Test]
        public void MessageWithLengthEqualTheBufferSizeReturnsOneItem()
        {
            var msg = "lorem amet";
            var result = Helper.Split(msg, bufferSize);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("lorem amet", result[0]);
        }

        [Test]
        public void MessageWithLengthEqualA15ReturnsTwoItems()
        {
            var msg = "lorem dolor sit";
            var result = Helper.Split(msg, bufferSize);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("lorem dolo", result[0]);
            Assert.AreEqual("r sit", result[1]);
        }

        [Test]
        public void MessageWithLengthEqualA20ReturnsTwoItems()
        {
            var msg = "lorem dolor sit amet";
            var result = Helper.Split(msg, bufferSize);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("lorem dolo", result[0]);
            Assert.AreEqual("r sit amet", result[1]);
        }

        [Test]
        public void MessageWithLengthEqualA25ReturnsThreeItems()
        {
            var msg = "lorem dolor sit amet elit";
            var result = Helper.Split(msg, bufferSize);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("lorem dolo", result[0]);
            Assert.AreEqual("r sit amet", result[1]);
            Assert.AreEqual(" elit", result[2]);
        }
    }
}
