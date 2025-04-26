using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Toaster
    {
        public void Toast()
        {
            Console.WriteLine("Toasting bread");
        }
    }

    public class Cooker
    {
        public void Cook()
        {
            Console.WriteLine("Cooking food");
        }
    }

    public class  WashingMachine
    {
        public void Wash()
        {
            Console.WriteLine("Washing clothes");
        }
    }

    public interface IAppliance
    {
        void Operate();
    }

    public class ToasterAdapter : IAppliance
    {
        private readonly Toaster _toaster;
        public ToasterAdapter(Toaster toaster)
        {
            _toaster = toaster;
        }
        public void Operate()
        {
            _toaster.Toast();
        }
    }

    public class CookerAdapter : IAppliance
    {
        private readonly Cooker _cooker;
        public CookerAdapter(Cooker cooker)
        {
            _cooker = cooker;
        }
        public void Operate()
        {
            _cooker.Cook();
        }
    }

    public class WashingMachineAdapter : IAppliance
    {
        private readonly WashingMachine _washingMachine;
        public WashingMachineAdapter(WashingMachine washingMachine)
        {
            _washingMachine = washingMachine;
        }
        public void Operate()
        {
            _washingMachine.Wash();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var toaster = new ToasterAdapter(new Toaster());
            var cooker = new CookerAdapter(new Cooker());
            var washingMachine = new WashingMachineAdapter(new WashingMachine());
            //toaster.Toast();
            //cooker.Cook();
            //washingMachine.Wash();

            toaster.Operate();
            cooker.Operate();
            washingMachine.Operate();
        }
    }
}
