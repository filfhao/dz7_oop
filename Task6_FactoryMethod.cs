using System;

// Завдання 6, шаблон Factory Method.
// Умова: є логістична компанія, яка доставляє вантаж. Залежно від типу
// логістики (автомобільна, морська, повітряна) створюється свій транспорт.
// Створення транспорту винесено у фабричний метод CreateTransport.
namespace Lab8.Task6_FactoryMethod
{
    interface ITransport
    {
        void Deliver(string cargo);
    }

    class Truck : ITransport
    {
        public void Deliver(string cargo)
        {
            Console.WriteLine("Вантажівка везе " + cargo + " по дорозі");
        }
    }

    class Ship : ITransport
    {
        public void Deliver(string cargo)
        {
            Console.WriteLine("Корабель везе " + cargo + " морем");
        }
    }

    class Plane : ITransport
    {
        public void Deliver(string cargo)
        {
            Console.WriteLine("Літак доставляє " + cargo + " повітрям");
        }
    }

    abstract class Logistics
    {
        public abstract ITransport CreateTransport();

        public void PlanDelivery(string cargo)
        {
            ITransport transport = CreateTransport();
            transport.Deliver(cargo);
        }
    }

    class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }

    class AirLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Plane();
        }
    }

    static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("Factory Method:");

            Logistics logistics = new RoadLogistics();
            logistics.PlanDelivery("меблі");

            logistics = new SeaLogistics();
            logistics.PlanDelivery("контейнер");

            logistics = new AirLogistics();
            logistics.PlanDelivery("посилку");

            Console.WriteLine();
        }
    }
}
