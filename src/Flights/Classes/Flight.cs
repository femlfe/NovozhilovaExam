using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Classes
{
    class Flight
    {
        public string PointStart { get; set; }
        public string PointEnd { get; set; }
        private int _hours;
        public int Hours {
            get
            {
                return _hours;
            }
            set
            {
                if (value >= 0 && value <= 24)
                {
                    _hours = value;
                }
                else
                    throw new ArgumentException("Величина 'часы' должнв быть в пределах 0 и 24 включительно");
            }
        }
        private int _minuts;

        public int Minuts {
            get
            {
                return _minuts;
            }
            set
            {
                if (value >= 0 && value < 60)
                {
                    _minuts = value;
                }
                else
                    throw new ArgumentException("Величина 'минуты' должна быть в пределах 0 и 60");
            }
        }

    }
}
