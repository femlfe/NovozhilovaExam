using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Flights.Classes
{
    class FlightControl
    {
        private List<Flight> _flights;

        public FlightControl()
        {
            _flights = new List<Flight>();
        }

        public void AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }

        public void Print()
        {
            foreach(Flight item in _flights)
            {
                Console.WriteLine($"{item.PointStart} - {item.PointEnd} - {item.Hours} - {item.Minuts}");
            }
        }

        public void SortFlightsHoustMinuts()
        {
            int lenth = _flights.Count();
            if (lenth > 0)
            {
                for (int i = 0; i < lenth; i++)
                {
                    for (int j = 0; j < lenth - 1; j++)
                    {
                        if (_flights[j].Hours > _flights[j + 1].Hours)
                        {
                            Flight flightTemp = _flights[j];
                            _flights[j] = _flights[j + 1];
                            _flights[j + 1] = flightTemp;
                        }
                        else if (_flights[j].Hours == _flights[j + 1].Hours)
                        {
                            if (_flights[j].Minuts > _flights[j + 1].Minuts)
                            {
                                Flight flightTemp = _flights[j];
                                _flights[j] = _flights[j + 1];
                                _flights[j + 1] = flightTemp;
                            }
                        }
                    }
                }

                //_flights = _flights.OrderBy(c => c.Hours).ThenBy(c => c.Minuts).ToList();
            }
            else
            {
                throw new Exception("Массив пуст");
            }
        }


        public void SaveToCsv()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(".\\flights.csv", false, Encoding.UTF8))
                {
                    sw.WriteLine("Пункт отправления;Пункт назначения;Час отправления;Минуты отправления");

                    foreach (Flight flight in _flights)
                    {
                        sw.WriteLine($"{flight.PointStart};{flight.PointEnd};{flight.Hours};{flight.Minuts}");
                    }
                    Console.WriteLine("Файл успешно сохранен и находится в папке проекта");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
