using System;
using Flights.Classes;

namespace Flights
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива (от 0 до 1000)");
            string? input = Console.ReadLine();

            int arrayLenth = 0;

            while (!(int.TryParse(input, out arrayLenth) && arrayLenth > 0 && arrayLenth <= 1000))
            {
                Console.WriteLine("Ошибка ввода!! \nВведите размер массива (целое число от 0 до 1000)");
                input = Console.ReadLine();
            }

            FlightControl flightControl = new FlightControl();



            for(int i = 0; i< arrayLenth; i++)
            {
                Flight flightTemp = new Flight();
                int tempInt = -1;
                Console.WriteLine($"\nВвод записи № {i+1}\n");

                Console.WriteLine("Введите пункт отправления");
                input = Console.ReadLine();
                while (input == "")
                {
                    Console.WriteLine("Ошибка ввода!! \nВведите пункт отправления");
                    input = Console.ReadLine();
                }
                flightTemp.PointStart = input;

                Console.WriteLine("Введите пункт прибытия");
                input = Console.ReadLine();
                while (input == "")
                {
                    Console.WriteLine("Ошибка ввода!! \nВведите пункт прибытия");
                    input = Console.ReadLine();
                }
                flightTemp.PointEnd = input;

                Console.WriteLine("Введите час отправления");
                input = Console.ReadLine();

    
                while (!(int.TryParse(input, out tempInt) && tempInt > 0 && tempInt <= 24) || input == "")
                {
                    Console.WriteLine("Ошибка ввода!! \nВведите час отправления (целое число от 0 до 24)");
                    input = Console.ReadLine();
                }

                try{
                    flightTemp.Hours = tempInt;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                tempInt = -1;


                Console.WriteLine("Введите минуты отправления");
                input = Console.ReadLine();

                while (!(int.TryParse(input, out tempInt) && tempInt >= 0 && tempInt < 60) || input == "")
                {
                    Console.WriteLine("Ошибка ввода!! \nВведите минуты отправления (целое число от 0 до 60)");
                    input = Console.ReadLine();
                }

                try
                {
                    flightTemp.Minuts = tempInt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                flightControl.AddFlight(flightTemp);
            }

            flightControl.SortFlightsHoustMinuts();

            flightControl.SaveToCsv();
        }
    }
}
