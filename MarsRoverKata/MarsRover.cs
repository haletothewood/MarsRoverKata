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
        private RoverDirection _direction = RoverDirection.North;
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
                case RoverDirection.North:
                    return "N";
                case RoverDirection.West:
                    return "W";
                case RoverDirection.South:
                    return "S";
                case RoverDirection.East:
                    return "E";
                default:
                    return null;
            }
        }

        private void CalculateDirection(char command)
        {
            switch (_direction)
            {
                case RoverDirection.North:
                    _direction = (command == 'L') ? RoverDirection.West : RoverDirection.East;
                    break;
                case RoverDirection.West:
                    _direction = (command == 'L') ? RoverDirection.South : RoverDirection.North;
                    break;
                case RoverDirection.South:
                    _direction = (command == 'L') ? RoverDirection.East : RoverDirection.West;
                    break;
                case RoverDirection.East:
                    _direction = (command == 'L') ? RoverDirection.North : RoverDirection.South;
                    break;
            }
        }
    }

    public enum RoverDirection
    {
        North,
        South,
        East,
        West, 
    }
}
