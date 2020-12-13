using Martijn.Extensions.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsTest
{
    class LinqTest
    {

        [Test]
        public async Task TestCombineWithString()
        {
            var res = new List<string> { "A", "B", "C"}.Combine("-");
            Assert.AreEqual("A-B-C", res);
        }

        [Test]
        public async Task TestCombineWithSpace()
        {
            var res = new List<string> { "A", "B", "C" }.Combine(" ");
            Assert.AreEqual("A B C", res);
        }

        [Test]
        public async Task TestCombineWithNewLine()
        {
            var res = new List<string> { "A", "B", "C" }.Combine("\n");
            Assert.AreEqual("A\nB\nC", res);
        }

        [Test]
        public async Task TestRepeat()
        {
            var res = new List<int> { 1, 1, 1 };
            Assert.AreEqual(1.Repeat(3), res);
        }

        [Test]
        public async Task TestComplement()
        {
            var me = new List<int> { 1, 2, 3 };
            var other = new List<int> { 3, 4, 5 };
            var res = new List<int> { 1, 2 };
            Assert.AreEqual(res, me.Complement(other).ToList());
        }
    }
}
