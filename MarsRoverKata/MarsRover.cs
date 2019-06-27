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
        private int _x;
        private int _y;
        private RoverDirection _direction = North;

        public string Execute(string input)
        {
            foreach (var command in input)
            {
                if (command == 'L' || command == 'R')
                {
                    CalculateDirection(command);
                }

                if (command == 'M')
                {
                    CalculateMovement();
                }
            }

            return $"{_x}:{_y}:{CalculatePosition()}";
        }

        private void CalculateMovement()
        {
            switch (_direction)
            {
                case North:
                    _x += 1;
                    break;
                case South:
                    _x -= 1;
                    break;
                case East:
                    _y += 1;
                    break;
                case West:
                    _y -= 1;
                    break;
            }
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
