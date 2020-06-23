using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AJConsoleUT;
using Moq;

namespace AJConsoleUTTest
{
    [TestClass]
    public class CoffeeMakerTest
    {
        [TestMethod]
        public void ExpressMaker_makes_espresso()
        {
            var grinderStub = new Mock<IBeanGrinder> ();
            grinderStub.Setup(g => g.Grind()).Returns(new Beans(true));

            var boilerFake = new FakeWaterBoiler();

            var portaFilterMock = new Mock<IPortaFilter>();

            var expressoMaker = new CoffeeMaker(
              grinderStub.Object,
              boilerFake,
              portaFilterMock.Object
              );

            var cup = CoffeeMaker.MakeCoffee();

            portaFilterMock.Verify(p => p.Load(It.Is<IBeans>(b => b.Ground)));
            portaFilterMock.Verify(p => p.Tamp(), "PortaFilter was not tamped");
            portaFilterMock.Verify(p => p.Push(It.Is<IWater>(w => w.Temprature > 90)));
            portaFilterMock.Verify(p => p.Receive(It.IsAny<Cup>()));
        }
    }
}
