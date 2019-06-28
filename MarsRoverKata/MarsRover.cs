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
        private Coordinate _coordinate = new Coordinate(0, 0);
        private RoverDirection _direction = North;

        public string Execute(string input)
        {
            foreach (var command in input)
            {
                if (command == 'L' || command == 'R')
                {
                    Turn(command);
                }

                if (command == 'M')
                {
                    _coordinate = Move();
                }
            }

            return $"{_coordinate.X}:{_coordinate.Y}:{Direction()}";
        }

        private Coordinate Move()
        {
            var x = _coordinate.X;
            var y = _coordinate.Y;
            
            switch (_direction)
            {
                case North:
                    x += 1;
                    break;
                case South:
                    x -= 1;
                    break;
                case East:
                    y += 1;
                    break;
                case West:
                    y -= 1;
                    break;
            }

            return new Coordinate(x, y);
        }

        private string Direction()
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

        private void Turn(char command)
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
