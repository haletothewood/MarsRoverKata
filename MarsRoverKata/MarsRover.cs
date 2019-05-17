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
            foreach (var command in input)
            {
                CalculateDirection(command);
            }

            return CalculatePosition();
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
