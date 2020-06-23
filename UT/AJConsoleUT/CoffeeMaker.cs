using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJConsoleUT
{
    public interface IBeanGrinder
    {
        Beans Grind();
    }

    public interface IBeans
    {
        bool Ground();
    }

    public interface IBoiler
    {
        void Boil(IWater water);
        //IWater water, ICup cup
    }

    public interface IPortaFilter
    {
        void Load(Beans beans);
        void Tamp();
        void Push(IWater water);
        void Receive(ICup cup);
    }

    public interface ICup
    {

    }

    interface ICoffeeMaker
    {
        ICup MakeCoffee();
    }

    public interface IWater
    {
        int Temprature { get; }
    }

    public class Beans : IBeanGrinder
    {
        bool ground;
        public bool Ground { get; set; }

        public Beans(bool ground)
        {
            Ground = ground;
        }

        public Beans Grind()
        {
            throw new NotImplementedException();
        }
    }

    public class Cup : ICup
    {
        public Cup()
        {
        }
    }

    public class EspressoMaker: ICoffeeMaker
    {
        private readonly IBeanGrinder _beanGrinder;
        private readonly IBoiler _waterBoiler;
        private readonly IPortaFilter _portaFilter;

        public EspressoMaker(IBeanGrinder beanGrinder, IBoiler waterBoiler, IPortaFilter portaFilter)
        {
            _beanGrinder = beanGrinder;
            _waterBoiler = waterBoiler;
            _portaFilter = portaFilter;
        }

        public ICup MakeCoffee()
        {
            var grinds = _beanGrinder.Grind();
            _portaFilter.Load(grinds);
            _portaFilter.Tamp();
            var cup = new Cup();
            _waterBoiler.Boil(w => OnWaterBoiled(w, cup)).Wait();
            return cup;
        }

        private void OnWaterBoiled(IWater water, ICup cup)
        {
            _portaFilter.Push(water);
            _portaFilter.Receive(cup);
        }
    }

    
}
