using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRoverKata.RoverDirection;

namespace MarsRoverKata
{
    public class MarsRover
    {
        private RoverDirection _direction = North;
        public string Execute(string input)
        {
            var x = 0;
            foreach (var command in input)
            {
                if (command == 'L' || command == 'R')
                {
                    CalculateDirection(command);
                }

                if (command == 'M')
                {
                    x += 1;
                }
            }

            return $"{x}:0:{CalculatePosition()}";
        }

        private string CalculatePosition()
        {
            switch (_direction)
            {
                case North:
                    return "N";
                case West:
                    return "W";
                case South:
                    return "S";
                case East:
                    return "E";
                default:
                    return null;
            }
        }

        private void CalculateDirection(char command)
        {
            switch (_direction)
            {
                case North:
                    _direction = (command == 'L') ? West : East;
                    break;
                case West:
                    _direction = (command == 'L') ? South : North;
                    break;
                case South:
                    _direction = (command == 'L') ? East : West;
                    break;
                case East:
                    _direction = (command == 'L') ? North : South;
                    break;
            }
        }
    }
}
