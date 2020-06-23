using AJConsoleUT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AJConsoleUTTest
{
    internal class FakeWaterBoiler : IBoiler
    {
       
        public Task Boil(Action<IWater> waterBoiled)
        {
            return Task.Factory.StartNew(() =>
            {
                var water = new Mock<IWater>();
                water.Setup(w => w.Temperature).Returns(95);
                waterBoiled(water.Object);
            });
        }
    }
}
