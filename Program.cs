using System;
using System.Text;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Лабораторне заняття 8 - шаблони проєктування");
                Console.WriteLine("1 - Abstract Factory");
                Console.WriteLine("2 - Builder");
                Console.WriteLine("3 - Mediator");
                Console.WriteLine("4 - Decorator");
                Console.WriteLine("5 - Prototype");
                Console.WriteLine("6 - Factory Method i Composite");
                Console.WriteLine("0 - Вихід");
                Console.Write("Введіть номер: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1") Task1_AbstractFactory.Demo.Run();
                else if (choice == "2") Task2_Builder.Demo.Run();
                else if (choice == "3") Task3_Mediator.Demo.Run();
                else if (choice == "4") Task4_Decorator.Demo.Run();
                else if (choice == "5") Task5_Prototype.Demo.Run();
                else if (choice == "6")
                {
                    Task6_FactoryMethod.Demo.Run();
                    Task6_Composite.Demo.Run();
                }
                else if (choice == "0") break;
                else Console.WriteLine("Такого пункту немає");
            }
        }
    }
}
