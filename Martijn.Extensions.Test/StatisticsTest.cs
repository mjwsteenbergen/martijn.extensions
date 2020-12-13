using Martijn.Extensions.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Martijn.Extensions.Statistics;
using System.Linq;

namespace ExtensionsTest
{
    class StatisticsTest
    {
        [Test]
        public async Task TestStandardDeviation()
        {
            var res = new List<double> { 727.7, 1086.5, 1091.0, 1361.3, 1490.5, 1956.1 };
            Assert.AreEqual(420.96, res.StandardDeviation(), 3);
        }
    }
}
