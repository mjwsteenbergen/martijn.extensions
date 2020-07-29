using Martijn.Extensions.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Martijn.Extensions.Numbers;
using System.Linq;

namespace ExtensionsTest
{
    class NumbersTest
    {
        [Test]
        public async Task TestMedianInt()
        {
            var res = new List<int> { 1, 2, 3 }.Median();
            Assert.AreEqual(2, res);
        }

        [Test]
        public async Task TestMedianDouble()
        {
            var res = new List<int> { 1, 2, 3 }.Median();
            Assert.AreEqual(2, res);
        }

        [Test]
        public async Task TestMedianDouble2()
        {
            var res = new List<double> { 1, 2, 3, 4 }.Median();
            Assert.AreEqual(2.5, res);
        }

        [Test]
        public async Task TestUntil()
        {
            var res = new List<double> { 1, 2, 3, 4 };
            Assert.AreEqual(res, 1.0.Until(4).ToList());
        }

        [Test]
        public async Task TestUntilSame()
        {
            var res = new List<double> { 1 };
            Assert.AreEqual(res, 1.0.Until(1).ToList());
        }

        [Test]
        public async Task TestUntilSteps()
        {
            var res = new List<double> { 0, 10, 20, 30, 40, 50 };
            Assert.AreEqual(res, 0.0.Until(50, 10).ToList());
        }

        [Test]
        public async Task TestUntilInt()
        {
            var res = new List<int> { 0, 10, 20, 30, 40, 50 };
            Assert.AreEqual(res, 0.Until(50, 10).ToList());
        }
    }
}
